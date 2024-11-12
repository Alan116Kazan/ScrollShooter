using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private AnimationCurve _movementCurve;

    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 4f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _moveDirection;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        GroundCheck();
        CharacterRotate();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    public void SetMoveDirection(Vector2 direction)
    {
        _moveDirection = direction;
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void CharacterRotate()
    {
        if (_moveDirection.x != 0)
        {
            _spriteRenderer.flipX = _moveDirection.x < 0;
        }
    }

    private void HorizontalMovement()
    {
        float movementModifier = _movementCurve.Evaluate(Mathf.Abs(_moveDirection.x));
        Vector2 targetVelocity = new Vector2(_moveDirection.x * _moveSpeed * movementModifier, _rb.velocity.y);
        _rb.velocity = new Vector2(targetVelocity.x, _rb.velocity.y);
    }

    private void GroundCheck()
    {
        _isGrounded = Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckDistance, _groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_groundCheck.position, _groundCheck.position + Vector3.down * _groundCheckDistance);
        }
    }
}
