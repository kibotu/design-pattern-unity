public interface ILogger
{
    void v(string message);

    void d(string message);

    void i(string message);

    void w(string message);

    void e(string message);

    void Log(object message);
    
    void Log(object message, UnityEngine.Object context);

    void LogWarning(object message);

    void LogWarning(object message, UnityEngine.Object context);
    
    void LogException(System.Exception exception);

    void LogException(System.Exception exception, UnityEngine.Object context);
    
    void LogError(object message);

    void LogError(object message, UnityEngine.Object contex);
}
