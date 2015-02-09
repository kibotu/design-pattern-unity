using UnityEngine;
using System.Collections;

public class SocketHandler : Singleton<SocketHandler> {
    
    public void Emit(string name, string json) 
    {
        Logger.Verbose("{0} : {1}", name, json);
    }
}
