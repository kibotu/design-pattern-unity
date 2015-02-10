using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class SingletonTest
{
    [Test]
    public void TestInstantiation()
    {
        Prefabs.Instance.GetPrefabByName("Cube");
        Prefabs.Instance.GetPrefabByName("Sphere");
        var prefabs = Prefabs.Instance;
        var sockets = SocketHandler.Instance;

        Debug.Init(new UnityDebugLogger(), Debug.Level.All);
        Debug.Log("a : b");

        if (prefabs != Prefabs.Instance)
        {
            Assert.Fail();
        }

        if (sockets != SocketHandler.Instance)
        {
            Assert.Fail();
        }
        
        Assert.Pass();
    }
}
