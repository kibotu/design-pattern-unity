using UnityEngine;
using System.Collections;

public static class Utils
{
    public static GameObject Instantiate(this GameObject prefab)
    {
        return GameObject.Instantiate(prefab);
    }

    public static Transform SetX(this Transform t, float x)
    {
        var p = t.position;
        p.x = x;
        t.position = p;
        return t;
    }
    
    public static Transform SetY(this Transform t, float y)
    {
        var p = t.position;
        p.y = y;
        t.position = p;
        return t;
    }
    
    public static Transform SetZ(this Transform t, float z)
    {
        var p = t.position;
        p.z = z;
        t.position = p;
        return t;
    }
    
    public static Transform SetXYZ(this Transform t, float x, float y, float z)
    {
        var p = t.position;
        p.x = x;
        p.x = y;
        p.x = z;
        t.position = p;
        return t;
    }
}