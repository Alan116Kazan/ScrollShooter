using UnityEngine;

/// <summary>
/// Класс для управления движением игрока во время катсцены.
/// </summary>
[RequireComponent(typeof(PlayerMovement))]
public class CutsceneInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
    }

    /// <summary>
    /// Устанавливает направление движения игрока.
    /// </summary>
    /// <param name="direction">Направление движения по оси X (-1 для влево, 1 для вправо, 0 для остановки).</param>
    private void SetMovement(float direction)
    {
        _playerMovement.SetMoveDirection(new Vector2(direction, 0));
    }

    /// <summary>
    /// Заставляет игрока двигаться вправо.
    /// </summary>
    public void MoveRight()
    {
        SetMovement(1f);
    }

    /// <summary>
    /// Заставляет игрока двигаться влево.
    /// </summary>
    public void MoveLeft()
    {
        SetMovement(-1f);
    }

    /// <summary>
    /// Останавливает движение игрока.
    /// </summary>
    public void Stop()
    {
        SetMovement(0f);
    }

    /// <summary>
    /// Включает управление игроком.
    /// </summary>
    public void PlayerInputOn()
    {
        if (_playerInput != null)
        {
            _playerInput.enabled = true;
        }
        else
        {
            Debug.LogWarning("PlayerInput компонент отсутствует на объекте.");
        }
    }

    /// <summary>
    /// Отключает управление игроком.
    /// </summary>
    public void PlayerInputOff()
    {
        if (_playerInput != null)
        {
            _playerInput.enabled = false;
        }
        else
        {
            Debug.LogWarning("PlayerInput компонент отсутствует на объекте.");
        }
    }
}