using System.Collections;
using CodeBase.Tool_s;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
  public class Manager : MonoBehaviour
  {
    protected Game Game;
    public Loader Loader;
    public Menu Menu;
    
    public bool IsDebug = true;
    
    public static Manager Instance { get; private set; }

    private SmartDebug _smartDebug;
    

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
      _smartDebug = new SmartDebug();

      if (!Game)
      {
        Game = GetComponentInChildren<Game>();
        _smartDebug.WarnLog(Constants.CLASS_Manager,
          "Game component was get from children object");
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
        if (Loader) 
          Loader.LoadSelectedScene(Constants.SCENE_Menu);
        if (Menu)
          Menu.MenuUI(true);
      }
    }
  }
}