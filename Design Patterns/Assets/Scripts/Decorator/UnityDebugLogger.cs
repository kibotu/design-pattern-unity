using UnityEngine;
using System.Collections;

public class UnityDebugLogger : ILogger {

    #region ILogger implementation

    public void v(string message)
    {
        Debug.Log(message);
    }

    public void d(string message)
    {
        Debug.Log(message);
    }

    public void i(string message)
    {
        Debug.Log(message);
    }

    public void w(string message)
    {
        Debug.LogWarning(message);
    }

    public void e(string message)
    {
        Debug.LogError(message);
    }

    #endregion
}
