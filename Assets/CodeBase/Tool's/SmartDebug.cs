using UnityEngine;

namespace CodeBase.Tool_s
{
  public class SmartDebug
  {
    public void SystemLog(string className, string msg)
    {
      Debug.Log(LogStyle.System($"[{className}] {msg}"));
    }
    
    public void GameLog(string className, string msg)
    {
      Debug.Log(LogStyle.Game($"[{className}] {msg}"));
    }
    
    public void WarnLog(string className, string msg)
    {
      Debug.LogWarning(LogStyle.Warning($"[{className}] {msg}"));
    }
    
    public void ErrorLog(string className, string msg)
    {
      Debug.LogError(LogStyle.Error($"[{className}] {msg}"));
    }
    
    public void SuccessLog(string className, string msg)
    {
      Debug.Log(LogStyle.Success($"[{className}] {msg}"));
    }
    
    public void InfoLog(string className, string msg)
    {
      Debug.Log(LogStyle.Info($"[{className}] {msg}"));
    }
  }
}