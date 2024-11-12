using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(Bow))]
public class PlayerInput : MonoBehaviour
{
    public const string HorizontalAxis = "Horizontal";
    public const string JumpButton = "Jump";
    public const string ShootButton = "Fire1";

    private PlayerMovement _playerMovement;
    private Bow _bow;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _bow = GetComponent<Bow>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis(HorizontalAxis);
        _playerMovement.SetMoveDirection(new Vector2(moveInput, 0));

        if (Input.GetButtonDown(JumpButton))
        {
            _playerMovement.Jump();
        }

        if (Input.GetButtonDown(ShootButton))
        {
            _bow.Shoot();
        }
    }
}