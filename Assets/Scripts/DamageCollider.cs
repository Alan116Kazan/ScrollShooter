using UnityEngine;

/// <summary>
/// ”правл€ет смещением и активацией коллайдера урона в зависимости от направлени€ персонажа.
/// </summary>
public class DamageCollider : MonoBehaviour
{
    [Header("Ќастройки коллайдера")]
    [Tooltip(" оллайдер, отвечающий за нанесение урона.")]
    [SerializeField] private Collider2D _damageCollider;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _originalOffset;
    private bool _lastFlipX;

    private void Awake()
    {
        if (_damageCollider is BoxCollider2D boxCollider)
        {
            _originalOffset = boxCollider.offset;
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lastFlipX = _spriteRenderer.flipX;
        UpdateColliderOffset();
    }

    private void Update()
    {
        ColliderFlip();
    }

    private void ColliderFlip()
    {
        if (_spriteRenderer.flipX != _lastFlipX)
        {
            _lastFlipX = _spriteRenderer.flipX;
            UpdateColliderOffset();
        }
    }
    private void UpdateColliderOffset()
    {
        Vector2 newOffset = _originalOffset;
        newOffset.x = _spriteRenderer.flipX ? Mathf.Abs(_originalOffset.x) : -Mathf.Abs(_originalOffset.x);

        if (_damageCollider is BoxCollider2D boxCollider)
        {
            boxCollider.offset = newOffset;
        }
        else if (_damageCollider is CircleCollider2D circleCollider)
        {
            circleCollider.offset = newOffset;
        }
    }

    public void ActivateCollider() => _damageCollider.enabled = true;

    public void DeactivateCollider() => _damageCollider.enabled = false;
}