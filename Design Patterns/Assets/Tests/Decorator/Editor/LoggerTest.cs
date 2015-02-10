using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class LoggerTest
{
    [Test]
    public void TestLogMessageNone()
    {
        var e = "TestLogMessageNone";
        var message = "fancy message";

        Debug.Init(new UnityDebugLogger(), Debug.Level.None);
        Debug.Verbose("{0} {1}", e, message);
        Debug.Log(e + " " + message);
        Debug.Info("{0} {1}", e, message);
        Debug.Warning("{0} {1}", e, message);
        Debug.Error("{0} {1}", e, message);

        Assert.Pass();
    }

    [Test]
    public void TestLogMessageVerbose()
    {
        var e = "TestLogMessageVerbose";
        var message = "fancy message";
        
        Debug.Init(new UnityDebugLogger(), Debug.Level.Verbose);
        Debug.Verbose("{0} {1}", e, message);
        Debug.Log(e + " " + message);
        Debug.Info("{0} {1}", e, message);
        Debug.Warning("{0} {1}", e, message);
        Debug.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageDebug()
    {
        var e = "TestLogMessageDebug";
        var message = "fancy message";
        
        Debug.Init(new UnityDebugLogger(), Debug.Level.Debug);
        Debug.Verbose("{0} {1}", e, message);
        Debug.Log(e + " " + message);
        Debug.Info("{0} {1}", e, message);
        Debug.Warning("{0} {1}", e, message);
        Debug.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageInfo()
    {
        var e = "TestLogMessageInfo";
        var message = "fancy message";
        
        Debug.Init(new UnityDebugLogger(), Debug.Level.Info);
        Debug.Verbose("{0} {1}", e, message);
        Debug.Log(e + " " + message);
        Debug.Info("{0} {1}", e, message);
        Debug.Warning("{0} {1}", e, message);
        Debug.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageWarning()
    {
        var e = "TestLogMessageWarning";
        var message = "fancy message";
        
        Debug.Init(new UnityDebugLogger(), Debug.Level.Warning);
        Debug.Verbose("{0} {1}", e, message);
        Debug.Log(e + " " + message);
        Debug.Info("{0} {1}", e, message);
        Debug.Warning("{0} {1}", e, message);
        Debug.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageError()
    {
        var e = "TestLogMessageError";
        var message = "fancy message";
        
        Debug.Init(new UnityDebugLogger(), Debug.Level.Error);
        Debug.Verbose("{0} {1}", e, message);
        Debug.Log(e + " " + message);
        Debug.Info("{0} {1}", e, message);
        Debug.Warning("{0} {1}", e, message);
        Debug.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageAll()
    {
        var e = "TestLogMessageAll";
        var message = "fancy message";
        
        Debug.Init(new UnityDebugLogger(), Debug.Level.All);
        Debug.Verbose("{0} {1}", e, message);
        Debug.Log(e + " " + message);
        Debug.Info("{0} {1}", e, message);
        Debug.Warning("{0} {1}", e, message);
        Debug.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void Clean()
    {
        Application.LoadLevel(0);
    }
}
