using UnityEngine;

/// <summary>
/// ��������� ����������� ������ �� ������ ����.
/// </summary>
public class EnemyDetection : MonoBehaviour
{
    [Header("Detection Settings")]
    [Tooltip("����� ������ ���� �����������.")]
    [SerializeField] private Transform _raycastOrigin;

    [Tooltip("������������ ��������� �����������.")]
    [SerializeField] private float _detectionRange = 5f;

    [Tooltip("����, �� ������� ��������� �����.")]
    [SerializeField] private LayerMask _playerLayer;

    /// <summary>
    /// ����������, ��������� �� ����� � ���� �����������.
    /// </summary>
    public bool PlayerInSight { get; private set; }

    private void Update()
    {
        PlayerInSight = DetectPlayer();
    }

    /// <summary>
    /// ���������, ��������� �� ����� � ���� �����������.
    /// </summary>
    /// <returns>���������� true, ���� ����� ���������.</returns>
    private bool DetectPlayer()
    {
        if (_raycastOrigin == null)
        {
            Debug.LogWarning("Raycast origin is not assigned!", this);
            return false;
        }

        // ��������� ��� � ����������� localScale.x
        RaycastHit2D detect = Physics2D.Raycast(_raycastOrigin.position, GetRayDirection(), _detectionRange, _playerLayer);

        // ���������, ����� �� ��� � ������ �� ���� ������
        return detect.collider != null;
    }

    /// <summary>
    /// ���������� ����������� ���� �� ������ ���������� �������� �������.
    /// </summary>
    /// <returns>������ ����������� ����.</returns>
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