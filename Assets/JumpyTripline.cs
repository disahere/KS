using UnityEngine;

public class JumpyTripline : MonoBehaviour
{
    private const string Player = "Player";

    [Header("General Settings")] [SerializeField]
    private float bounceForce = 20f;

    [SerializeField] private float bounceCooldown = 0.5f;

    private bool _isReadyToBounce = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");
        if (other.CompareTag(Player) && _isReadyToBounce)
        {
            Debug.Log("Trigger Pleyer");
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}