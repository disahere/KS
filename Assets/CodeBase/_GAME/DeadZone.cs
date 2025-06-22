using CodeBase.Tool_s;
using UnityEngine;

namespace CodeBase._GAME
{
  public class DeadZone : MonoBehaviour
  {
    [SerializeField] private GameObject respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (!other.gameObject.CompareTag(Constants.TAGS_Player)) return;
      
      other.gameObject.transform.position = respawnPoint.transform.position;
    }
  }
}