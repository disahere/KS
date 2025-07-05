using CodeBase.Infrastructure;
using CodeBase.Tool_s;
using UnityEngine;

namespace CodeBase._GAME
{
  public class GameManager : MonoBehaviour
  {
    [Header("Level Settings")] 
    [SerializeField] private int cristalTarget;
    
    [SerializeField] private Loader loader;
    [SerializeField] private Menu menu;

    private void Start()
    {
      InitComp();
    }

    private void InitComp()
    {
      
    }

    public int ReturnCristalTarget()
    {
      return cristalTarget;
    }
    
    public void Win()
    {
      loader.LoadSelectedScene(Constants.SCENE_Menu);
      menu.MenuUI(true);
      menu.GameUI(false);
    }

    public void Lose()
    {
      loader.LoadSelectedScene(Constants.SCENE_Game);
    }
  }
}