using _Code.Tools.SmartDebug;
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
      DLogger.Message(DSenders.Application)
        .WithText($"{Constants.CLASS_JumpyTripline} On Trigger Enter".Bold())
        .WithFormat(DebugFormat.Normal)
        .Log();

      if (!other.CompareTag(Constants.TAGS_Player) || !_isReadyToBounce) return;

      DLogger.Message(DSenders.Application)
        .WithText($"{Constants.CLASS_JumpyTripline} Player contact with tripline".Bold())
        .WithFormat(DebugFormat.Normal)
        .Log();

      var rb = other.GetComponent<Rigidbody2D>();
      if (!rb) return;

      rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
      rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }
  }
}