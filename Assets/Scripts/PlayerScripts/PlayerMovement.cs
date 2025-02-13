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
    [SerializeField] private float _jumpDelay = 0.2f;
    [SerializeField] private float _accelerationTime = 0.2f;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    private Vector2 _moveDirection;
    private bool _isGrounded;
    private float _lastGroundContactTime = 0f;
    private float _velocityXSmoothing;

    public Vector2 Velocity => _rb.velocity;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        PerformHorizontalMovement();
        UpdateRotation();
        CheckGroundStatus();
    }

    /// <summary>
    /// ������������� ����������� �������� ������.
    /// </summary>
    public void SetMoveDirection(Vector2 direction)
    {
        _moveDirection = direction;
    }

    /// <summary>
    /// ��������� ������, ���� ����� �� ����� � �������� � ������� ����������� ������.
    /// </summary>
    public void Jump()
    {
        // ���������, ��� ����� �� ����� � � ������� ������� ����� ������ ������ �����
        if (_isGrounded && (Time.time - _lastGroundContactTime) >= _jumpDelay)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    /// <summary>
    /// ��������� ����������� �������� ������.
    /// </summary>
    private void UpdateRotation()
    {
        if (_moveDirection.x == 0) return;

        bool isFacingLeft = _moveDirection.x < 0;
        _spriteRenderer.flipX = isFacingLeft;

        AdjustColliderOffset(isFacingLeft);
        AdjustGroundCheckPosition(isFacingLeft);
    }

    /// <summary>
    /// ����������� ������.
    /// </summary>
    private void PerformHorizontalMovement()
    {
        float movementModifier = _movementCurve.Evaluate(Mathf.Abs(_moveDirection.x));
        float targetVelocityX = _moveDirection.x * _moveSpeed * movementModifier;

        // ������ ���������� ������� �������� � �������:
        float smoothedVelocityX = Mathf.SmoothDamp(_rb.velocity.x, targetVelocityX, ref _velocityXSmoothing, _accelerationTime);

        _rb.velocity = new Vector2(smoothedVelocityX, _rb.velocity.y);
    }

    /// <summary>
    /// ���������, ��������� �� ����� �� �����, � ��������� ����� ������� ��������.
    /// </summary>
    private void CheckGroundStatus()
    {
        // ��������� ���������� ���������
        bool wasGrounded = _isGrounded;
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckDistance, _groundLayer);

        // ���� ����� ������ ��� �������� ����� (��� � �������, � ������ �� �����)
        if (_isGrounded && !wasGrounded)
        {
            _lastGroundContactTime = Time.time;
        }
    }

    /// <summary>
    /// ����������� �������� ���������� ��� ��������� �����������.
    /// </summary>
    private void AdjustColliderOffset(bool isFacingLeft)
    {
        Vector2 colliderOffset = _collider.offset;
        colliderOffset.x = Mathf.Abs(colliderOffset.x) * (isFacingLeft ? 1 : -1);
        _collider.offset = colliderOffset;
    }

    /// <summary>
    /// ����������� ��������� ����� �������� ����� ��� ��������� �����������.
    /// </summary>
    private void AdjustGroundCheckPosition(bool isFacingLeft)
    {
        Vector2 groundCheckPosition = _groundCheck.localPosition;
        groundCheckPosition.x = Mathf.Abs(groundCheckPosition.x) * (isFacingLeft ? 1 : -1);
        _groundCheck.localPosition = groundCheckPosition;
    }
}