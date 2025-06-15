using UnityEngine;

namespace CodeBase.Tool_s
{
  public class SmartDebug
  {
    public void Log(string className, string msg)
    {
      Debug.Log($"[{className}] {msg}");
    }
  }
}