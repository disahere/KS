using CodeBase.Tool_s;

namespace CodeBase.Infrastructure
{
  public class Game : Manager
  {
    protected SmartDebug SmartDebug;

    protected readonly bool IsDebug = true;
    private void Awake()
    {
      SmartDebug = new SmartDebug();
    }
  }
}