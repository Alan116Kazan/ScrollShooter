using UnityEngine;

/// <summary>
/// Поведение обнаружения игрока на основе луча.
/// </summary>
public class EnemyDetection : MonoBehaviour
{
    [Header("Detection Settings")]
    [Tooltip("Точка начала луча обнаружения.")]
    [SerializeField] private Transform _raycastOrigin;

    [Tooltip("Максимальная дальность обнаружения.")]
    [SerializeField] private float _detectionRange = 5f;

    [Tooltip("Слой, на котором находится игрок.")]
    [SerializeField] private LayerMask _playerLayer;

    /// <summary>
    /// Показывает, находится ли игрок в зоне обнаружения.
    /// </summary>
    public bool PlayerInSight { get; private set; }

    private void Update()
    {
        PlayerInSight = DetectPlayer();
    }

    /// <summary>
    /// Проверяет, находится ли игрок в зоне обнаружения.
    /// </summary>
    /// <returns>Возвращает true, если игрок обнаружен.</returns>
    private bool DetectPlayer()
    {
        if (_raycastOrigin == null)
        {
            Debug.LogWarning("Raycast origin is not assigned!", this);
            return false;
        }

        // Выпускаем луч в направлении localScale.x
        RaycastHit2D detect = Physics2D.Raycast(_raycastOrigin.position, GetRayDirection(), _detectionRange, _playerLayer);

        // Проверяем, попал ли луч в объект на слое игрока
        return detect.collider != null;
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
            Gizmos.color = PlayerInSight ? Color.red : Color.green;
            Gizmos.DrawLine(_raycastOrigin.position, _raycastOrigin.position + (Vector3)GetRayDirection() * _detectionRange);
        }
    }
}