using UnityEngine;

/// <summary>
/// Класс, управляющий поведением врага: патрулирование, преследование игрока и атака.
/// </summary>
[RequireComponent(typeof(EnemyPatrol))]
[RequireComponent(typeof(EnemyDetection))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyChase))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [Header("Ссылки на компоненты")]
    private EnemyPatrol _enemyPatrol;
    private EnemyDetection _enemyDetection;
    private EnemyAttack _enemyAttack;
    private EnemyChase _enemyChase;

    private Rigidbody2D _enemyRigidbody2D;

    /// <summary>
    /// Текущая скорость врага.
    /// </summary>
    public float CurrentVelocity { get; private set; }

    /// <summary>
    /// Свойство для доступа к Rigidbody2D.
    /// </summary>
    public Rigidbody2D Rb => _enemyRigidbody2D;

    private void Awake()
    {
        // Получение необходимых компонентов
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyDetection = GetComponent<EnemyDetection>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyChase = GetComponent<EnemyChase>();
        _enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Обновление состояний врага в зависимости от условий
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

        // Обновление текущей скорости врага
        CurrentVelocity = _enemyRigidbody2D.velocity.magnitude;
    }

    /// <summary>
    /// Обработка состояния атаки.
    /// </summary>
    private void HandleAttackState()
    {
        _enemyChase.enabled = false;
        _enemyPatrol.enabled = false;
        _enemyRigidbody2D.velocity = Vector2.zero; // Остановка врага
    }

    /// <summary>
    /// Обработка состояния преследования игрока.
    /// </summary>
    private void HandleChaseState()
    {
        _enemyChase.enabled = true;
        _enemyPatrol.enabled = false;
    }

    /// <summary>
    /// Обработка состояния патрулирования.
    /// </summary>
    private void HandlePatrolState()
    {
        _enemyPatrol.enabled = true;
        _enemyChase.enabled = false;
    }
}