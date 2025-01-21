using UnityEngine;

/// <summary>
/// ��������� �����, ������������, ��������� �� ����� � ���� ������������.
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [Tooltip("����� ������ ���� �����.")]
    [SerializeField] private Transform _raycastOrigin;

    [Tooltip("������������ ��������� �����.")]
    [SerializeField] private float _attackRange = 1.5f;

    [Tooltip("����, �� ������� ��������� �����.")]
    [SerializeField] private LayerMask _playerLayer;

    /// <summary>
    /// ����, �����������, ��������� �� ����� � ���� �����.
    /// </summary>
    public bool IsAttacking { get; private set; }

    private void Update()
    {
        IsAttacking = CheckAttackRange();
    }

    /// <summary>
    /// ���������, ��������� �� ����� � ���� �����.
    /// </summary>
    /// <returns>���������� true, ���� ����� � ���� �����.</returns>
    private bool CheckAttackRange()
    {
        if (_raycastOrigin == null)
        {
            Debug.LogWarning("Raycast origin is not assigned!", this);
            return false;
        }

        // ��������� ��� � ����������� localScale.x
        RaycastHit2D hit = Physics2D.Raycast(_raycastOrigin.position, GetRayDirection(), _attackRange, _playerLayer);

        // ���������, ��� ������ ����������� ���� ������
        return hit.collider != null;
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
            Gizmos.color = IsAttacking ? Color.red : Color.blue;
            Gizmos.DrawLine(_raycastOrigin.position, _raycastOrigin.position + (Vector3)GetRayDirection() * _attackRange);
        }
    }
}