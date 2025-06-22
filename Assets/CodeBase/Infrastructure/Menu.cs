using CodeBase.Tool_s;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure
{
  public class Menu : Game
  {
    [Header("Panel's")] 
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;

    [Header("Button's")] 
    [SerializeField] private Button startGame;

    [Header("Loader's")]
    [SerializeField] private Loader loader;
    
    private SmartDebug _smartDebug;
    
    private void Awake()
    {
      MenuUI(false);
      GameUI(false);
      SmartDebug = new SmartDebug();
    }

    private void Start()
    {
      startGame.onClick.AddListener(() => {
        if (loader)
        {
          loader.LoadSelectedScene(Constants.SCENE_Game);
          MenuUI(false);
          GameUI(true);
        }
      });
    }

    public void MenuUI(bool isActive)
    {
      menuPanel.gameObject.SetActive(isActive);
    }
    
    public void GameUI(bool isActive)
    {
      gamePanel.gameObject.SetActive(isActive);
    }
  }
}