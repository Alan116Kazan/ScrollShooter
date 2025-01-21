using UnityEngine;

/// <summary>
/// �����, ���������� �� ������������� ������ ������.
/// </summary>
[RequireComponent(typeof(EnemyPatrol))]
[RequireComponent(typeof(EnemyController))]
public class EnemyChase : MonoBehaviour
{
    [Header("��������� ��������")]
    [Tooltip("������ �� ������ ������.")]
    [SerializeField] private Transform _player;

    [Tooltip("�������� �������������.")]
    [SerializeField] private float _moveSpeed = 5f;

    [Tooltip("��������� ��� �������� ��������� ��������.")]
    [SerializeField] private float _acceleration = 10f;

    private EnemyPatrol _enemyPatrol;
    private EnemyController _enemyController;

    private void Awake()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyController = GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        if (_player != null)
        {
            Rigidbody2D rb = _enemyController.Rb;

            // ������������ ����������� �������� � ������
            Vector2 direction = (_player.position - transform.position).normalized;

            // C������� �����
            Vector2 targetVelocity = direction * _moveSpeed;

            // ������� ��������� ������� ��������
            Vector2 velocity = Vector2.Lerp(rb.velocity, targetVelocity, _acceleration * Time.fixedDeltaTime);

            // ��������� ������������ ��������
            rb.velocity = new Vector2(velocity.x, rb.velocity.y);

            // ������������ ����� � ������� ������
            HandleFlip(direction.x);
        }
    }

    /// <summary>
    /// ������������ ������� ����� � ������� ������.
    /// </summary>
    /// <param name="directionX">�������� �� ��� X, ����������� ����������� � ������.</param>
    private void HandleFlip(float directionX)
    {
        // ���� ����������� X �������������� �������� ����������� �����, ��������� �������
        if (Mathf.Sign(directionX) != Mathf.Sign(transform.localScale.x))
        {
            _enemyPatrol.Flip(); // ������������
        }
    }
}