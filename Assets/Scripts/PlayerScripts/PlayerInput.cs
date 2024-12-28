using UnityEngine;

/// <summary>
/// Класс для обработки ввода игрока и взаимодействия с компонентами движения и атаки.
/// </summary>
[RequireComponent(typeof(PlayerMovement), typeof(PlayerAttack))]
public class PlayerInput : MonoBehaviour
{
    // Константы для имен осей ввода и кнопок
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

    /// <summary>
    /// Обрабатывает ввод, связанный с движением и прыжком.
    /// </summary>
    private void HandleMovement()
    {
        // Если игрок атакует, движение блокируется
        if (_playerAttack.IsFiring)
        {
            _playerMovement.SetMoveDirection(Vector2.zero);
            return;
        }

        // Получение значения оси движения
        float moveInput = Input.GetAxis(HorizontalAxis);
        _playerMovement.SetMoveDirection(new Vector2(moveInput, 0));

        // Обработка прыжка
        if (Input.GetButtonDown(JumpButton))
        {
            _playerMovement.Jump();
        }
    }

    /// <summary>
    /// Обрабатывает ввод, связанный с атакой.
    /// </summary>
    private void HandleAttack()
    {
        // Начало атаки при нажатии кнопки
        if (Input.GetButtonDown(ShootButton))
        {
            _playerAttack.StartAttack();
        }

        // Завершение атаки при отпускании кнопки
        if (Input.GetButtonUp(ShootButton))
        {
            _playerAttack.EndAttack();
        }
    }
}