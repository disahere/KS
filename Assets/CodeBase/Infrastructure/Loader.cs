using _Code.Tools.SmartDebug;
using CodeBase.Tool_s;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
  public class Loader : MonoBehaviour
  {
    public void LoadSelectedScene(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
      DLogger.Message(DSenders.GameState)
        .WithText($"{Constants.CLASS_Loader} Loading scene: {sceneName} started!".Bold())
        .WithFormat(DebugFormat.Normal)
        .Log();
    }
  }
}