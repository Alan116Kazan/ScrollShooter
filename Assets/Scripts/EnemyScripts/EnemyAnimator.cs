using UnityEngine;

/// <summary>
/// Класс для управления анимациями врага, основанными на его состоянии и поведении.
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyController))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private Health _health;
    private EnemyAttack _attackBehavior;
    private EnemyController _enemyController;

    private float _previousVelocity = 0f;

    private void Awake()
    {
        // Получение необходимых компонентов
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _attackBehavior = GetComponent<EnemyAttack>();
        _enemyController = GetComponent<EnemyController>();
    }

    private void Update()
    {
        UpdateAnimations();
    }

    /// <summary>
    /// Метод для обновления всех анимаций врага.
    /// </summary>
    private void UpdateAnimations()
    {
        PlayDeathAnimation();
        PlayWalkAnimation();
        PlayAttackAnimation();
    }

    /// <summary>
    /// Играет анимацию смерти, если враг мёртв.
    /// </summary>
    private void PlayDeathAnimation()
    {
        if (_health != null && !_health.IsAlive)
        {
            _animator.SetTrigger("Dead");
        }
    }

    /// <summary>
    /// Обновляет анимацию ходьбы на основе скорости врага.
    /// </summary>
    private void PlayWalkAnimation()
    {
        float velocity = _enemyController.CurrentVelocity;

        // Проверяем изменение скорости для оптимального обновления анимации
        if (!Mathf.Approximately(velocity, _previousVelocity))
        {
            _animator.SetFloat("Velocity", velocity);
            _previousVelocity = velocity;
        }
    }

    /// <summary>
    /// Играет анимацию атаки, если враг атакует.
    /// </summary>
    private void PlayAttackAnimation()
    {
        if (_health != null && _health.IsAlive && _attackBehavior.IsAttacking)
        {
            _animator.SetTrigger("Attack");
        }
    }
}