using System.Runtime.InteropServices;
using UnityEngine;
 
public class CookieManager
{
    [DllImport("__Internal")]
    private static extern void SetCurrentState(int state);
 
    [DllImport("__Internal")]
    private static extern int GetCurrentState();
 
    public void SetStateCookie(int state)
    {
        if (CheckWebGLPlatform()) {
            SetCurrentState(state);
        }
    }
 
    public int GetStateCookie()
    {
        int state = 0;
 
        if (CheckWebGLPlatform()) {
            state = GetCurrentState();
        }
 
        return state;
    }
 
    protected bool CheckWebGLPlatform()
    {
        return Application.platform == RuntimePlatform.WebGLPlayer;
    }
}