using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMovement))]
public class ArcherAnimations : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Health _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        RunAndFly();

        if (_health.IsAlive == false)
        {
            PlayDeathAnimation();
        }
    }

    private void RunAndFly()
    {
        bool isMoving = Mathf.Abs(_playerMovement.Velocity.x) > 0.1f;
        bool isGrounded = _playerMovement.IsGrounded;

        _animator.SetBool("IsRunning", isMoving && isGrounded);
        _animator.SetBool("IsFly", !isGrounded);
    }

    public void PlayDeathAnimation()
    {
        _animator.SetBool("IsDead", true);
    }

    public void LandedOff()
    {
        _animator.SetBool("IsLanded", false);
    }

    public void LandedOn()
    {
        _animator.SetBool("IsLanded", true);
    }

    public void AttackAnimation(bool isAttack)
    {
        _animator.SetBool("IsAttack", isAttack);
    }
}