public class UnityDebugLogger : ILogger
{
    #region ILogger implementation

    public void v(string message)
    {
        Log(message);
    }

    public void d(string message)
    {
        Log(message);
    }

    public void i(string message)
    {
        Log(message);
    }

    public void w(string message)
    {
        LogWarning(message);
    }

    public void e(string message)
    {
        LogError(message);
    }

    public void Log(object message)
    {
        UnityEngine.Debug.Log(message);
    }

    public void Log(object message, UnityEngine.Object context)
    {
        UnityEngine.Debug.Log(message, context);
    }

    public void LogWarning(object message)
    {
        UnityEngine.Debug.LogWarning(message);
    }

    public void LogWarning(object message, UnityEngine.Object context)
    {
       UnityEngine.Debug.LogWarning(message, context);
    }

    public void LogException(System.Exception exception)
    {
        UnityEngine.Debug.LogException(exception);
    }

    public void LogException(System.Exception exception, UnityEngine.Object context)
    {
       UnityEngine.Debug.LogException(exception, context);
    }

    public void LogError(object message)
    {
        UnityEngine.Debug.LogError(message);
    }

    public void LogError(object message, UnityEngine.Object context)
    {
       UnityEngine.Debug.LogError(message, context);
    }

    #endregion
}
