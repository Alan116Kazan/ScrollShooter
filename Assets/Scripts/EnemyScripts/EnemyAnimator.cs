using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private Health _health;
    private EnemyController _enemyController;

    private float _previousVelocity = 0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _enemyController = GetComponent<EnemyController>();
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        PlayDeathAnimation();
        WalkAnimation();
        AttackAnimation();
    }

    private void PlayDeathAnimation()
    {
        if (_health != null && !_health.IsAlive)
        {
            _animator.SetTrigger("Dead");
        }
    }

    private void WalkAnimation()
    {
        float velocity = _enemyController.CurrentVelocity;
        if (!Mathf.Approximately(velocity, _previousVelocity))
        {
            _animator.SetFloat("Velocity", velocity);
            _previousVelocity = velocity;
        }
    }

    private void AttackAnimation()
    {
        if (_enemyController.IsAttacking)
        {
            _animator.SetTrigger("Attack");
        }
    }
}