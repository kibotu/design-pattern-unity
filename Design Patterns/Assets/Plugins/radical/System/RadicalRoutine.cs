using UnityEngine;
using System.Collections;
using System;

public class CoroutineReturn
{
	public virtual bool finished {get;set;}
	public virtual bool cancel {get;set;}
}

public class WaitForAnimation : CoroutineReturn
{
	private GameObject _go;
	private string _name;
	private float _time;
	private float _weight;
	private bool first = true;
	private int startFrame;
	public string name
	{
		get
		{
			return _name;
		}
	}
	
	public WaitForAnimation(GameObject go, string name, float time=1f, float weight = -1)
	{
		startFrame = Time.frameCount;
		_go = go;
		_name = name;
		_time = Mathf.Clamp01(time);
		_weight = weight;
	}
	
	public override bool finished {
		get {
			if(Time.frameCount <= startFrame+1)
			{
				first = false;
				return false;
			}
			if(_weight == -1)
			{
				return !_go.GetComponent<Animation>()[_name].enabled || _go.GetComponent<Animation>()[_name].normalizedTime >= _time || _go.GetComponent<Animation>()[_name].weight == 0 || _go.GetComponent<Animation>()[_name].speed == 0;
			}
			else
			{
				if(_weight < 0.5)
				{
					var w = _go.GetComponent<Animation>()[_name].weight;
					return _go.GetComponent<Animation>()[_name].weight <= Mathf.Clamp01(_weight);
				}
				return _go.GetComponent<Animation>()[_name].weight >= Mathf.Clamp01(_weight);
			}
		}
		set {
			base.finished = value;
		}
	}
	
}

public static class TaskHelpers
{
	public static WaitForAnimation WaitForAnimation(this GameObject go, string name, float time = 1f)
	{
		return new WaitForAnimation(go, name, time,-1);
	}
	public static WaitForAnimation WaitForAnimationWeight(this GameObject go, string name, float weight=0f)
	{
		return new WaitForAnimation(go, name, 0, weight);
	}
}

public class RadicalRoutine  {
	
	private bool cancel;
	public IEnumerator enumerator;
	public event Action Cancelled;
	public event Action Finished;
	
	public void Cancel()
	{
		cancel = true;
	}
	
	private static RadicalRoutine own = new RadicalRoutine();
	
	public static IEnumerator Run(IEnumerator extendedCoRoutine)
	{
		return own.Execute(extendedCoRoutine);
	}
	
	public static RadicalRoutine Create(IEnumerator extendedCoRoutine)
	{
		var rr = new RadicalRoutine();
		rr.enumerator = rr.Execute(extendedCoRoutine);
		return rr;
	}
	
	private IEnumerator Execute(IEnumerator extendedCoRoutine)
	{
		while(!cancel && extendedCoRoutine != null && extendedCoRoutine.MoveNext())
		{
			var v = extendedCoRoutine.Current;
			var cr = v as CoroutineReturn;
			if(cr != null)
			{
				if(cr.cancel) 
				{
					cancel = true;
					break;
				}
				while(!cr.finished)
				{
					if(cr.cancel) 
					{
						cancel = true;
						break;
					}
					yield return new WaitForEndOfFrame();
				}
			} else 
			{
				yield return v;
			}
		}
		
		if(cancel && Cancelled != null)
		{
			Cancelled();
		}
		if(Finished != null)
		{
			Finished();
		}
		
	}
	
	
}
