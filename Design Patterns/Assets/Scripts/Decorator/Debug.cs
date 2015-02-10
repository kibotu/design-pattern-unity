public class Debug
{
    [System.Flags]
    public enum Level
    {
        None        = 0,                //        0
        Verbose     = 1,                //        1
        Debug       = 2,                //       10
        Info        = 4,                //      100
        Warning     = 8,                //     1000
        Exception   = 16,               //    10000
        Error       = 32,               //   100000      
        All         = 63                //   111111
    }

    private static ILogger _logger = null;
    private static Level _level = Level.None;

    public static Level LogLevel
    {
        get { return _level; }
        set { _level = value; }
    }

    public static bool isDebugBuild
    {
        get
        {
            return UnityEngine.Debug.isDebugBuild;
        }
    }

    public static void Init(ILogger log, Level logLevel)
    {
        Debug._logger = log;
        Debug.LogLevel = logLevel;
    }

    protected static bool IsValid(Level request)
    {
        return Debug._logger != null && (request & Debug.LogLevel) != 0;
    }

    public static void Verbose(string format, params object[] args)
    {
        if (IsValid(Level.Verbose))
            _logger.v(string.Format(format, args));
    }

    public static void Info(string format, params object[] args)
    {
        if (IsValid(Level.Info))
            _logger.i(string.Format(format, args));
    }

    public static void Warning(string format, params object[] args)
    {
        if (IsValid(Level.Warning))
            _logger.w(string.Format(format, args));
    }

    public static void Error(string format, params object[] args)
    {
        if (IsValid(Level.Error))
            _logger.e(string.Format(format, args));
    }

    #region inject constrains

    public static void Log(object message)
    {
        if (IsValid(Level.Verbose))
            _logger.Log(message);
    }
   
    public static void Log(object message, UnityEngine.Object context)
    {
        if (IsValid(Level.Verbose))
            _logger.Log(message, context);
    }

    public static void LogWarning(object message)
    {
        if (IsValid(Level.Warning))
            _logger.LogWarning(message);
    }

    public static void LogWarning(object message, UnityEngine.Object context)
    {
        if (IsValid(Level.Warning))
            _logger.LogWarning(message, context);
    }

    public static void LogException(System.Exception exception)
    {
        if (IsValid(Level.Exception))
            _logger.LogException(exception);
    }

    public static void LogException(System.Exception exception, UnityEngine.Object context)
    {
        if (IsValid(Level.Exception))
            _logger.LogException(exception, context);
    }

    public static void LogError(object message)
    {
        if (IsValid(Level.Error))
            _logger.LogError(message);
    }

    public static void LogError(object message, UnityEngine.Object context)
    {
        if (IsValid(Level.Error))
            _logger.LogError(message, context);
    }

    #endregion
}
