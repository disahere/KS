using System.Collections;
using _Code.Tools.SmartDebug;
using CodeBase.Tool_s;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
  public class Manager : MonoBehaviour
  {
    [SerializeField] private Game Game;
    [SerializeField] private Loader Loader;
    [SerializeField] private Menu Menu;
    
    public static Manager Instance { get; private set; }
    
    private void Awake()
    {
      if (Instance && Instance != this)
      {
        Destroy(gameObject);
        return;
      }
      else
      {
        Instance = this;
        DontDestroyOnLoad(gameObject);
      }
    }

    private void Start()
    {
      RegisterAllComponents();
      StartCoroutine(CheckActiveScene());
    }

    private void RegisterAllComponents()
    {
      if (!Game)
      {
        Game = GetComponentInChildren<Game>();
        DLogger.Message(DSenders.Assets)
          .WithText($"{Constants.CLASS_Manager} Game component was get from children object".Bold())
          .WithFormat(DebugFormat.Normal)
          .Log();
      }

      if (!Loader)
        Loader = GetComponentInChildren<Loader>();

      if (!Menu)
        Menu = GetComponentInChildren<Menu>();
    }

    private IEnumerator CheckActiveScene()
    {
      yield return new WaitForSeconds(Constants.GameCheckCooldown);
      
      if (SceneManager.GetActiveScene().name == Constants.SCENE_Bootstrap)
      {
        // if (Loader) 
        //   Loader.LoadSelectedScene(Constants.SCENE_Menu);
        if (Menu)
          Menu.MenuUI(true);
      }
    }
  }
}