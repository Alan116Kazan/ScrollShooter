using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAttack))]
public class PlayerInput : MonoBehaviour
{
    public const string HorizontalAxis = "Horizontal";
    public const string JumpButton = "Jump";
    public const string ShootButton = "Fire1";

    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    private void HandleMovement()
    {
        if (_playerAttack.IsFiring)
        {
            _playerMovement.SetMoveDirection(Vector2.zero);
            return;
        }

        float moveInput = Input.GetAxis(HorizontalAxis);
        _playerMovement.SetMoveDirection(new Vector2(moveInput, 0));

        if (Input.GetButtonDown(JumpButton))
        {
            _playerMovement.Jump();
        }
    }

    private void HandleAttack()
    {
        if (Input.GetButtonDown(ShootButton))
        {
            _playerAttack.StartAttack();
        }

        if (Input.GetButtonUp(ShootButton))
        {
            _playerAttack.EndAttack();
        }
    }
}