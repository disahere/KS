using CodeBase.Tool_s;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase._GAME
{
  public class CristalCollector : MonoBehaviour
  {
    private int _cristalCollected;
    private int _cristalNeeded;
    
    //TODO: Переписати передачу UI 
    private GameUI _ui;
    private GameManager _gm;

    private void Start()
    {
      InitComp();
      SetupLevelSettings();
    }

    private void InitComp()
    {
      if (!_ui)
        _ui = FindObjectOfType<GameUI>();
      
      if (!_gm)
        _gm = FindObjectOfType<GameManager>();
    }

    private void SetupLevelSettings()
    {
      _cristalNeeded = _gm.ReturnCristalTarget();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.CompareTag(Constants.TAGS_Cristal))
      {
        _cristalCollected++;
        _ui.UpdateCoins(_cristalCollected);
        if (_cristalNeeded == _cristalCollected)
          _gm.Win();
        
        Destroy(other.gameObject);
      }
    }
  }
}