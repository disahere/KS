using System.Collections;
using CodeBase.Tool_s;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
  public class Manager : MonoBehaviour
  {
    private Game _game;
    private Loader _loader;
    
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
      if(!_game)
        _game = GetComponentInChildren<Game>();

      if (!_loader)
        _loader = GetComponentInChildren<Loader>();
    }

    private IEnumerator CheckActiveScene()
    {
      yield return new WaitForSeconds(Constants.GameCheckCooldown);
      
      if (SceneManager.GetActiveScene().name == Constants.SCENE_Bootstrap)
      {
        _loader.LoadSelectedScene(Constants.SCENE_Menu);
      }
    }
  }
}