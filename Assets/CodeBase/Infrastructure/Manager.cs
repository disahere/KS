using System.Collections;
using CodeBase.Tool_s;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
  public class Manager : MonoBehaviour
  {
    protected Game Game;
    protected Loader Loader;
    protected Menu Menu;
    
    protected readonly bool IsDebug = true;
    
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
      if(!Game)
        Game = GetComponentInChildren<Game>();

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