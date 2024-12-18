using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Bow _bow;
    private PlayerMovement _playerMovement;

    private bool _isFiring;
    private float _fireButtonPressedTime;
    private float _chargeTime = 0.3f;

    public bool IsFiring => _isFiring;

    private void Awake()
    {
        _bow = GetComponent<Bow>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void StartAttack()
    {
        if (!_playerMovement.IsGrounded) return;

        _isFiring = true;
        _fireButtonPressedTime = Time.time;
    }

    public void EndAttack()
    {
        if (!_isFiring) return;

        _isFiring = false;

        if (Time.time - _fireButtonPressedTime > _chargeTime)
        {
            _bow.Shoot();
        }
    }
}