using UnityEngine;

/// <summary>
/// ����� ��� ���������� ���������� �������, ������� ��������, ����� � ������.
/// </summary>
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

    /// <summary>
    /// ��������� ��� ������������ ���������.
    /// </summary>
    private void UpdateAnimations()
    {
        UpdateRunAndFlyAnimation();
        UpdateDeathAnimation();
        UpdateAttackAnimation();
    }

    /// <summary>
    /// ��������� �������� ���� � ������.
    /// </summary>
    private void UpdateRunAndFlyAnimation()
    {
        bool isMoving = Mathf.Abs(_playerMovement.Velocity.x) > 0.1f;
        bool isGrounded = _playerMovement.IsGrounded;

        _animator.SetBool("IsRunning", isMoving && isGrounded);
        _animator.SetBool("IsFly", !isGrounded);
    }

    /// <summary>
    /// ��������� �������� ������.
    /// </summary>
    private void UpdateDeathAnimation()
    {
        _animator.SetBool("IsDead", !_health.IsAlive);
    }

    /// <summary>
    /// ��������� �������� �����.
    /// </summary>
    private void UpdateAttackAnimation()
    {
        _animator.SetBool("IsAttack", _attack.IsFiring);
    }

    /// <summary>
    /// ��������� �������� �����������.
    /// </summary>
    public void LandedOff()
    {
        _animator.SetBool("IsLanded", false);
    }

    /// <summary>
    /// �������� �������� �����������.
    /// </summary>
    public void LandedOn()
    {
        _animator.SetBool("IsLanded", true);
    }
}