using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMovement))]
public class ArcherAnimations : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Health _health;
    private PlayerAttack _attack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _health = GetComponent<Health>();
        _attack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        RunAndFly();
        PlayDeathAnimation();
        AttackAnimation();
    }

    private void RunAndFly()
    {
        bool isMoving = Mathf.Abs(_playerMovement.Velocity.x) > 0.1f;
        bool isGrounded = _playerMovement.IsGrounded;

        _animator.SetBool("IsRunning", isMoving && isGrounded);
        _animator.SetBool("IsFly", !isGrounded);
    }

    private void PlayDeathAnimation()
    {
        if (_health.IsAlive == false)
        {
            _animator.SetBool("IsDead", true);
        }
    }

    private void AttackAnimation()
    {
        _animator.SetBool("IsAttack", _attack.IsFiring);
    }

    public void LandedOff()
    {
        _animator.SetBool("IsLanded", false);
    }

    public void LandedOn()
    {
        _animator.SetBool("IsLanded", true);
    }
}