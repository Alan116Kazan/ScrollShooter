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
    private Collider2D _collider;
    private Vector2 _moveDirection;
    private bool _isGrounded;


    public Vector2 Velocity => _rb.velocity;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        CharacterRotate();
    }

    private void FixedUpdate()
    {
        GroundCheck();
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

            Vector2 offset = _collider.offset;
            offset.x = Mathf.Abs(offset.x) * (_spriteRenderer.flipX ? 1 : -1);
            _collider.offset = offset;
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
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckDistance, _groundLayer);
    }

}
