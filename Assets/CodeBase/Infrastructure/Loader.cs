using CodeBase.Tool_s;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
  public class Loader : Game
  {
    public void LoadSelectedScene(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
      SmartDebug.Log(Constants.CLASS_Loader, $"Loading scene: {sceneName} started!");
    }
  }
}