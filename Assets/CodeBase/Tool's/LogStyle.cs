namespace CodeBase.Tool_s
{
  public static class LogStyle
  {
    public static string System(string text)
    {
      return $"<b><color=#2196F3>{text}</color></b>";
    }

    public static string Game(string text)
    {
      return $"<i><color=#4CAF50>{text}</color></i>";
    }
    
    public static string Success(string text)
    {
      return $"<b><color=#4CAF50>{text}</color></b>";
    }
    
    public static string Info(string text)
    {
      return $"<b><color=#2196F3>{text}</color></b>";
    }
    
    public static string Warning(string text)
    {
      return $"<b><color=#FFC107>{text}</color></b>";
    }
    
    public static string Error(string text)
    {
      return $"<b><color=#F44336>{text}</color></b>";
    }
  }
}