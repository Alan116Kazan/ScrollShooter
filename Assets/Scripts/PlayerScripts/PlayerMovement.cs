using UnityEngine;

/// <summary>
/// Класс для управления движением игрока, включая бег, прыжки и вращение.
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Скорость передвижения игрока.")]
    [SerializeField] private float _moveSpeed = 2f;

    [Tooltip("Кривая модификатора движения.")]
    [SerializeField] private AnimationCurve _movementCurve;

    [Header("Jump Settings")]
    [Tooltip("Сила прыжка.")]
    [SerializeField] private float _jumpForce = 4f;

    [Tooltip("Слой, обозначающий землю.")]
    [SerializeField] private LayerMask _groundLayer;

    [Tooltip("Точка проверки соприкосновения с землей.")]
    [SerializeField] private Transform _groundCheck;

    [Tooltip("Дистанция проверки соприкосновения с землей.")]
    [SerializeField] private float _groundCheckDistance = 0.1f;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private Vector2 _moveDirection;
    private bool _isGrounded;

    /// <summary>
    /// Текущая скорость игрока.
    /// </summary>
    public Vector2 Velocity => _rb.velocity;

    /// <summary>
    /// Находится ли игрок на земле.
    /// </summary>
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
    /// Устанавливает направление движения игрока.
    /// </summary>
    /// <param name="direction">Направление движения.</param>
    public void SetMoveDirection(Vector2 direction)
    {
        _moveDirection = direction;
    }

    /// <summary>
    /// Выполняет прыжок игрока.
    /// </summary>
    public void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    /// <summary>
    /// Обновляет направление поворота игрока.
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
    /// Перемещение игрока.
    /// </summary>
    private void PerformHorizontalMovement()
    {
        float movementModifier = _movementCurve.Evaluate(Mathf.Abs(_moveDirection.x));
        Vector2 targetVelocity = new Vector2(_moveDirection.x * _moveSpeed * movementModifier, _rb.velocity.y);
        _rb.velocity = new Vector2(targetVelocity.x, _rb.velocity.y);
    }

    /// <summary>
    /// Проверяет, находится ли игрок на земле.
    /// </summary>
    private void CheckGroundStatus()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckDistance, _groundLayer);
    }

    /// <summary>
    /// Настраивает смещение коллайдера при изменении направления.
    /// </summary>
    /// <param name="isFacingLeft">Смотрит ли игрок влево.</param>
    private void AdjustColliderOffset(bool isFacingLeft)
    {
        Vector2 colliderOffset = _collider.offset;
        colliderOffset.x = Mathf.Abs(colliderOffset.x) * (isFacingLeft ? 1 : -1);
        _collider.offset = colliderOffset;
    }

    /// <summary>
    /// Настраивает положение точки проверки земли при изменении направления.
    /// </summary>
    /// <param name="isFacingLeft">Смотрит ли игрок влево.</param>
    private void AdjustGroundCheckPosition(bool isFacingLeft)
    {
        Vector2 groundCheckPosition = _groundCheck.localPosition;
        groundCheckPosition.x = Mathf.Abs(groundCheckPosition.x) * (isFacingLeft ? 1 : -1);
        _groundCheck.localPosition = groundCheckPosition;
    }
}