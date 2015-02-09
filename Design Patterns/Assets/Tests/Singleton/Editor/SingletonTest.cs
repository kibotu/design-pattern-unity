using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class SingletonTest {

    [Test]
    public void TestInstantiation () {
        Prefabs.Instance.GetPrefabByName("Cube");
        Prefabs.Instance.GetPrefabByName("Sphere");
        var prefabs = Prefabs.Instance;
        var sockets = SocketHandler.Instance;

        Logger.Init(new UnityDebugLogger(), Logger.Level.All);
        Logger.Debug("{0} : {1}", "a", "b");
        Logger.Debug("a : b");

        if(prefabs != Prefabs.Instance)
        {
            Assert.Fail();
        }

        if(sockets != SocketHandler.Instance)
        {
            Assert.Fail();
        }
        
        Assert.Pass();
    }

    [Test]
    public void CleanUp() 
    {
        Application.LoadLevel(0);
    }
}
