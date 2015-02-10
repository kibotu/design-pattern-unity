using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoroutineManager : MonoBehaviour
{
	static CoroutineManager _instance = null;

	public static CoroutineManager instance {
		get {
			if (!_instance)
			{
				_instance = FindObjectOfType(typeof(CoroutineManager)) as CoroutineManager;

				if (!_instance)
				{
					var obj = new GameObject ("CoroutineManager");
					Object.DontDestroyOnLoad(obj);
					obj.hideFlags = HideFlags.HideAndDontSave;			
					_instance = obj.AddComponent<CoroutineManager>();
				}
			}
			return _instance;
		}
	}

	void OnApplicationQuit()
	{
		_instance = null;
	}
}

public class Job
{
	public event System.Action<bool> jobComplete;

	private bool _running;

	public bool running { get { return _running; } }

	private bool _paused;
	private float _delayStart;

	public bool paused { get { return _paused; } }

	private IEnumerator _coroutine;
	private bool _jobWasKilled;
	private Stack<Job> _childJobStack;
	
	private MonoBehaviour _coroutineHost;

	#region constructors

	public Job (IEnumerator coroutine, MonoBehaviour coroutineHost = null, bool shouldStart = true, float delayStart = -1)
	{	
		_coroutine = coroutine;
		_coroutineHost = coroutineHost;
		if (_coroutineHost == null)
		{			
			_coroutineHost = CoroutineManager.instance;
		}		
		
		_delayStart = delayStart;
		if (shouldStart)
		{
			start();		
		}
	}

	#endregion

	#region static Job makers

	public static Job make(IEnumerator coroutine, MonoBehaviour coroutineHost = null, bool shouldStart = true, float delayStart = -1)
	{
		return new Job (coroutine, coroutineHost, shouldStart, delayStart);
	}

	#endregion

	private IEnumerator doWork()
	{
		if (_delayStart > -1)
		{
			yield return _delayStart == 0 ? null : new WaitForSeconds(_delayStart);
		}

		while(_running)
		{
			if (_paused)
			{
				yield return null;
			}
			else
			{
				// run the next iteration and stop if we are done
				if (_coroutine.MoveNext())
				{
					yield return _coroutine.Current;
				}
				else
				{
					// run our child jobs if we have any
					if (_childJobStack != null && _childJobStack.Count > 0)
					{
						Job childJob = _childJobStack.Pop();
						_coroutine = childJob._coroutine;
					}
					else
						_running = false;
				}
			}
		}
		
		// fire off a complete event
		if (jobComplete != null)
			jobComplete(_jobWasKilled);
	}

	#region public API

	public Job createAndAddChildJob(IEnumerator coroutine)
	{
		var j = new Job (coroutine, _coroutineHost, false);
		addChildJob(j);
		return j;
	}

	public void addChildJob(Job childJob)
	{
		if (_childJobStack == null)
			_childJobStack = new Stack<Job> ();
		_childJobStack.Push(childJob);
	}

	public void removeChildJob(Job childJob)
	{
		if (_childJobStack.Contains(childJob))
		{
			var childStack = new Stack<Job> (_childJobStack.Count - 1);
			var allCurrentChildren = _childJobStack.ToArray();
			System.Array.Reverse(allCurrentChildren);
			
			for(var i = 0; i < allCurrentChildren.Length; i++)
			{
				var j = allCurrentChildren[i];
				if (j != childJob)
					childStack.Push(j);
			}
			
			// assign the new stack
			_childJobStack = childStack;
		}
	}

	public void start()
	{
		_running = true;
		_coroutineHost.StartCoroutine(doWork());
	}

	public IEnumerator startAsCoroutine()
	{
		_running = true;
		yield return _coroutineHost.StartCoroutine(doWork());
	}

	public void pause()
	{
		_paused = true;
	}

	public void unpause()
	{
		_paused = false;
		if (!_running)
		{
			start();
		}
	}

	public void kill()
	{
		_jobWasKilled = true;
		_running = false;
		_paused = false;
	}

	public void kill(float delayInSeconds)
	{
		var delay = (int) (delayInSeconds * 1000);
		new System.Threading.Timer (obj =>
		{
			lock(this)
			{
				kill();
			}
		}, null, delay, System.Threading.Timeout.Infinite);
	}

	#endregion

}