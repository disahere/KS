using CodeBase.Tool_s;

namespace CodeBase.Infrastructure
{
  public class Game : Manager
  {
    protected SmartDebug SmartDebug;

    private void Awake()
    {
      SmartDebug = new SmartDebug();
    }
  }
}