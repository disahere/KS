using CodeBase.Infrastructure;
using CodeBase.Tool_s;
using UnityEngine;

namespace CodeBase._GAME
{
  public class JumpyTripline : Game
  {
    [Header("General Settings")] [SerializeField]
    private float bounceForce = 10f;
    private readonly bool _isReadyToBounce = true;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (IsDebug) 
        SmartDebug.Log(Constants.CLASS_JumpyTripline, "On Trigger Enter");
      
      if (!other.CompareTag(Constants.TAGS_Player) || !_isReadyToBounce) return;
    
      if (IsDebug)
        SmartDebug.Log(Constants.CLASS_JumpyTripline, "Player contact with tripline");
    
      var rb = other.GetComponent<Rigidbody2D>();
      if (!rb) return;
    
      rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
      rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }
  }
}