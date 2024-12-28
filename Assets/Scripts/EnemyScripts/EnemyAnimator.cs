using UnityEngine;

/// <summary>
/// ����� ��� ���������� ���������� �����, ����������� �� ��� ��������� � ���������.
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
        // ��������� ����������� �����������
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
    /// ����� ��� ���������� ���� �������� �����.
    /// </summary>
    private void UpdateAnimations()
    {
        PlayDeathAnimation();
        PlayWalkAnimation();
        PlayAttackAnimation();
    }

    /// <summary>
    /// ������ �������� ������, ���� ���� ����.
    /// </summary>
    private void PlayDeathAnimation()
    {
        if (_health != null && !_health.IsAlive)
        {
            _animator.SetTrigger("Dead");
        }
    }

    /// <summary>
    /// ��������� �������� ������ �� ������ �������� �����.
    /// </summary>
    private void PlayWalkAnimation()
    {
        float velocity = _enemyController.CurrentVelocity;

        // ��������� ��������� �������� ��� ������������ ���������� ��������
        if (!Mathf.Approximately(velocity, _previousVelocity))
        {
            _animator.SetFloat("Velocity", velocity);
            _previousVelocity = velocity;
        }
    }

    /// <summary>
    /// ������ �������� �����, ���� ���� �������.
    /// </summary>
    private void PlayAttackAnimation()
    {
        if (_health != null && _health.IsAlive && _attackBehavior.IsAttacking)
        {
            _animator.SetTrigger("Attack");
        }
    }
}