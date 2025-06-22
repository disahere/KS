using CodeBase.Infrastructure;
using CodeBase.Tool_s;
using UnityEngine;

namespace CodeBase._GAME
{
  public class GameManager : Game
  {
    [Header("Level Settings")] 
    [SerializeField] private int cristalTarget;

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
      Loader.LoadSelectedScene(Constants.SCENE_Menu);
      Menu.MenuUI(true);
      Menu.GameUI(false);
    }

    public void Lose()
    {
      Loader.LoadSelectedScene(Constants.SCENE_Game);
    }
  }
}