using System.Collections;

public class SocketHandler : Singleton<SocketHandler> {
    
    public void Emit(string name, string json) 
    {
        Debug.Verbose("{0} : {1}", name, json);
    }
}
