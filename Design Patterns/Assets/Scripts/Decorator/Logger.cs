using UnityEngine;
using System.Collections;
using System;

public class Logger : Singleton<Logger>, ILogger
{
    [Flags]
    public enum Level
    {
        None    = 0,                //        0
        Verbose = 1,                //        1
        Debug   = 2,                //       10
        Info    = 4,                //      100
        Warning = 8,                //     1000
        Error   = 16,               //    10000
        All     = 63                //   111111
    }

    protected ILogger log;
    public Level LogLevel;

    public static void Init(ILogger log, Level logLevel)
    {
        Instance.log = log;
        Instance.LogLevel = logLevel;
    }

    protected static bool IsValid(Level request)
    {
        return Instance.log != null && Instance.LogLevel != null && (request & Instance.LogLevel) != 0;
    }

    public static void Verbose(string format, params object[] args)
    {
        if (IsValid(Level.Verbose))
            Instance.v(string.Format(format, args));
    }

    public static void Debug(string format, params object[] args)
    {
        if (IsValid(Level.Debug))
            Instance.d(string.Format(format, args));
    }

    public static void Info(string format, params object[] args)
    {
        if (IsValid(Level.Info))
            Instance.i(string.Format(format, args));
    }

    public static void Warning(string format, params object[] args)
    {
        if (IsValid(Level.Warning))
            Instance.w(string.Format(format, args));
    }

    public static void Error(string format, params object[] args)
    {
        if (IsValid(Level.Error))
            Instance.e(string.Format(format, args));
    }

    #region ILogger implementation

    public void v(string message)
    {
        log.v(message);
    }

    public void d(string message)
    {
        log.d(message);
    }

    public void i(string message)
    {
        log.i(message);
    }

    public void w(string message)
    {
        log.w(message);
    }

    public void e(string message)
    {
        log.e(message);
    }

    #endregion

}
