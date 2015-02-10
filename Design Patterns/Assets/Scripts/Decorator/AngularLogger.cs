using UnityEngine;
using System.Collections;

public class AngularLogger : ILogger
{
    #region talking to angular

    private const string URL = "http://localhost:3000/api/";
    private const string TOKEN = "token";

    private static void Post(string model, WWWForm form)
    {
        CoroutineManager.instance.StartCoroutine(_Post(model, form));
    }
    
    private static IEnumerator _Post(string model, WWWForm form)
    {
        WWW www = new WWW(URL + model, form);
        yield return www;
    }

    #endregion

    #region ILogger implementation

    public void v(string message)
    {

    }

    public void d(string message)
    {
    }

    public void i(string message)
    {
    }

    public void w(string message)
    {
    }

    public void e(string message)
    {
    }

    public void Log(object message)
    {
        UnityEngine.Debug.Log("sending message to server: " + message);

        WWWForm data = new WWWForm();
        data.AddField("LogMessage", message.ToString());
        data.AddField("Severity", Debug.Level.Verbose.ToString());
        data.AddField("Timestamp", 0);

        AngularLogger.Post("UnityDebugLogModels?access_token=" + TOKEN, data);
    }

    public void Log(object message, Object context)
    {
    }

    public void LogWarning(object message)
    {
    }

    public void LogWarning(object message, Object context)
    {
    }

    public void LogException(System.Exception exception)
    {
    }

    public void LogException(System.Exception exception, Object context)
    {
    }

    public void LogError(object message)
    {
    }

    public void LogError(object message, Object contex)
    {
    }

    #endregion
}
