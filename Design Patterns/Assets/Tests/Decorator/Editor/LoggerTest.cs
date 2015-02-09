using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class LoggerTest  {

    [Test]
    public void TestLogMessageNone() {

        var e = "TestLogMessageNone";
        var message = "fancy message";

        Logger.Init(new UnityDebugLogger(), Logger.Level.None);
        Logger.Verbose("{0} {1}", e, message);
        Logger.Debug("{0} {1}", e, message);
        Logger.Info("{0} {1}", e, message);
        Logger.Warning("{0} {1}", e, message);
        Logger.Error("{0} {1}", e, message);

        Assert.Pass();
    }

    [Test]
    public void TestLogMessageVerbose() {

        var e = "TestLogMessageVerbose";
        var message = "fancy message";
        
        Logger.Init(new UnityDebugLogger(), Logger.Level.Verbose);
        Logger.Verbose("{0} {1}", e, message);
        Logger.Debug("{0} {1}", e, message);
        Logger.Info("{0} {1}", e, message);
        Logger.Warning("{0} {1}", e, message);
        Logger.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageDebug() {

        var e = "TestLogMessageDebug";
        var message = "fancy message";
        
        Logger.Init(new UnityDebugLogger(), Logger.Level.Debug);
        Logger.Verbose("{0} {1}", e, message);
        Logger.Debug("{0} {1}", e, message);
        Logger.Info("{0} {1}", e, message);
        Logger.Warning("{0} {1}", e, message);
        Logger.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageInfo() {

        var e = "TestLogMessageInfo";
        var message = "fancy message";
        
        Logger.Init(new UnityDebugLogger(), Logger.Level.Info);
        Logger.Verbose("{0} {1}", e, message);
        Logger.Debug("{0} {1}", e, message);
        Logger.Info("{0} {1}", e, message);
        Logger.Warning("{0} {1}", e, message);
        Logger.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageWarning() {

        var e = "TestLogMessageWarning";
        var message = "fancy message";
        
        Logger.Init(new UnityDebugLogger(), Logger.Level.Warning);
        Logger.Verbose("{0} {1}", e, message);
        Logger.Debug("{0} {1}", e, message);
        Logger.Info("{0} {1}", e, message);
        Logger.Warning("{0} {1}", e, message);
        Logger.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageError() {

        var e = "TestLogMessageError";
        var message = "fancy message";
        
        Logger.Init(new UnityDebugLogger(), Logger.Level.Error);
        Logger.Verbose("{0} {1}", e, message);
        Logger.Debug("{0} {1}", e, message);
        Logger.Info("{0} {1}", e, message);
        Logger.Warning("{0} {1}", e, message);
        Logger.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }

    [Test]
    public void TestLogMessageAll() {

        var e = "TestLogMessageAll";
        var message = "fancy message";
        
        Logger.Init(new UnityDebugLogger(), Logger.Level.All);
        Logger.Verbose("{0} {1}", e, message);
        Logger.Debug("{0} {1}", e, message);
        Logger.Info("{0} {1}", e, message);
        Logger.Warning("{0} {1}", e, message);
        Logger.Error("{0} {1}", e, message);
        
        Assert.Pass();
    }
}
