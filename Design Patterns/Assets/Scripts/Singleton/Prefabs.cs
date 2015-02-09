using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Prefabs : MonoBehaviour
{
    #region Singleton

    [SerializeField]
    protected static Prefabs
        _instance;
    
    /// <summary>
    /// Returns the instance of this singleton.
    /// </summary>
    /// <value>The instance.</value>
    public static Prefabs Instance
    {
        get
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = _instance ?? (_instance = (Resources.Load("Prefabs", typeof(GameObject)) as GameObject).GetComponent<Prefabs>());
                    Debug.Log("Created Singleton: " + typeof(Prefabs));
                }
            }
            
            return _instance;
        }
    }

    #endregion

    public GameObject[] prefabs;

    public GameObject GetPrefabByName(string name)
    {
        GameObject result = null;

        foreach (var go in prefabs)
        {
            if (go.name.Equals(name))
            {
                result = go;
                break;
            }
        }
        return result == null ? null : result.Instantiate();
    }
}