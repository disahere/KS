using UnityEngine;

namespace CodeBase._GAME
{
  public class Move : MonoBehaviour
  {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D _rb;
    private bool _isGrounded;
    private readonly float _groundRadius = 0.2f;

    private void Start() =>
      _rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
      #region Jump

      _isGrounded = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, whatIsGround);

      if (Input.GetButtonDown("Jump") && _isGrounded)
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);

      #endregion

      #region Side

      var horizontal = Input.GetAxis("Horizontal");
      if (horizontal != 0)
        transform.localScale = new Vector3(Mathf.Sign(-horizontal), 1f, 1f);

      #endregion
    }

    private void FixedUpdate()
    {
      var move = Input.GetAxis("Horizontal");
      _rb.linearVelocity = new Vector2(move * moveSpeed, _rb.linearVelocity.y);
    }
  }
}