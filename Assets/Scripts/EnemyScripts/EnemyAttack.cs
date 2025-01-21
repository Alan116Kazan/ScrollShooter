using UnityEngine;

/// <summary>
/// Поведение атаки, определяющее, находится ли игрок в зоне досягаемости.
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [Tooltip("Точка начала луча атаки.")]
    [SerializeField] private Transform _raycastOrigin;

    [Tooltip("Максимальная дальность атаки.")]
    [SerializeField] private float _attackRange = 1.5f;

    [Tooltip("Слой, на котором находится игрок.")]
    [SerializeField] private LayerMask _playerLayer;

    /// <summary>
    /// Флаг, указывающий, находится ли игрок в зоне атаки.
    /// </summary>
    public bool IsAttacking { get; private set; }

    private void Update()
    {
        IsAttacking = CheckAttackRange();
    }

    /// <summary>
    /// Проверяет, находится ли игрок в зоне атаки.
    /// </summary>
    /// <returns>Возвращает true, если игрок в зоне атаки.</returns>
    private bool CheckAttackRange()
    {
        if (_raycastOrigin == null)
        {
            Debug.LogWarning("Raycast origin is not assigned!", this);
            return false;
        }

        // Выпускаем луч в направлении localScale.x
        RaycastHit2D hit = Physics2D.Raycast(_raycastOrigin.position, GetRayDirection(), _attackRange, _playerLayer);

        // Проверяем, что объект принадлежит слою игрока
        return hit.collider != null;
    }

    /// <summary>
    /// Определяет направление луча на основе локального масштаба объекта.
    /// </summary>
    /// <returns>Вектор направления луча.</returns>
    private Vector2 GetRayDirection()
    {
        return Vector2.right * Mathf.Sign(transform.localScale.x);
    }

    private void OnDrawGizmos()
    {
        if (_raycastOrigin != null)
        {
            Gizmos.color = IsAttacking ? Color.red : Color.blue;
            Gizmos.DrawLine(_raycastOrigin.position, _raycastOrigin.position + (Vector3)GetRayDirection() * _attackRange);
        }
    }
}