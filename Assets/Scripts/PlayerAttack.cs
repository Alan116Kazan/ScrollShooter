using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Bow _bow;
    private ArcherAnimations _archerAnimations;
    private PlayerMovement _playerMovement;

    private bool _isFiring;
    private float _fireButtonPressedTime;
    private float _chargeTime = 0.3f;

    public bool IsFiring => _isFiring;

    private void Awake()
    {
        _bow = GetComponent<Bow>();
        _archerAnimations = GetComponent<ArcherAnimations>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void StartAttack()
    {
        if (!_playerMovement.IsGrounded) return;

        _isFiring = true;
        _fireButtonPressedTime = Time.time;
        _archerAnimations.AttackAnimation(true);
    }

    public void EndAttack()
    {
        if (!_isFiring) return;

        _isFiring = false;
        _archerAnimations.AttackAnimation(false);

        if (Time.time - _fireButtonPressedTime > _chargeTime)
        {
            _bow.Shoot();
        }
    }
}