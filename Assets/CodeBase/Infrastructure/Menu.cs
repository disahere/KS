using CodeBase.Tool_s;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure
{
  public class Menu : Game
  {
    [Header("Panel's")] 
    [SerializeField] private GameObject menuPanel;

    [Header("Button's")] 
    [SerializeField] private Button startGame;

    private Loader _loader;
    private SmartDebug _smartDebug;
    
    private void Awake()
    {
      MenuUI(false);
      _loader = FindObjectOfType<Loader>();
      SmartDebug = new SmartDebug();
    }

    private void Start()
    {
      startGame.onClick.AddListener(() => {
        if (_loader)
        {
          _loader.LoadSelectedScene(Constants.SCENE_Game);
          MenuUI(false);
        }
      });
    }

    public void MenuUI(bool isActive)
    {
      menuPanel.gameObject.SetActive(isActive);
    }
  }
}