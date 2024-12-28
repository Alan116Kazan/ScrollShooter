using UnityEngine;

/// <summary>
/// �����, ����������� ���������� �����: ��������������, ������������� ������ � �����.
/// </summary>
[RequireComponent(typeof(EnemyPatrol))]
[RequireComponent(typeof(EnemyDetection))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyChase))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [Header("������ �� ����������")]
    private EnemyPatrol _enemyPatrol;
    private EnemyDetection _enemyDetection;
    private EnemyAttack _enemyAttack;
    private EnemyChase _enemyChase;

    private Rigidbody2D _enemyRigidbody2D;

    /// <summary>
    /// ������� �������� �����.
    /// </summary>
    public float CurrentVelocity { get; private set; }

    /// <summary>
    /// �������� ��� ������� � Rigidbody2D.
    /// </summary>
    public Rigidbody2D Rb => _enemyRigidbody2D;

    private void Awake()
    {
        // ��������� ����������� �����������
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyDetection = GetComponent<EnemyDetection>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyChase = GetComponent<EnemyChase>();
        _enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // ���������� ��������� ����� � ����������� �� �������
        if (_enemyAttack.IsAttacking)
        {
            HandleAttackState();
        }
        else if (_enemyDetection.PlayerInSight)
        {
            HandleChaseState();
        }
        else
        {
            HandlePatrolState();
        }

        // ���������� ������� �������� �����
        CurrentVelocity = _enemyRigidbody2D.velocity.magnitude;
    }

    /// <summary>
    /// ��������� ��������� �����.
    /// </summary>
    private void HandleAttackState()
    {
        _enemyChase.enabled = false;
        _enemyPatrol.enabled = false;
        _enemyRigidbody2D.velocity = Vector2.zero; // ��������� �����
    }

    /// <summary>
    /// ��������� ��������� ������������� ������.
    /// </summary>
    private void HandleChaseState()
    {
        _enemyChase.enabled = true;
        _enemyPatrol.enabled = false;
    }

    /// <summary>
    /// ��������� ��������� ��������������.
    /// </summary>
    private void HandlePatrolState()
    {
        _enemyPatrol.enabled = true;
        _enemyChase.enabled = false;
    }
}