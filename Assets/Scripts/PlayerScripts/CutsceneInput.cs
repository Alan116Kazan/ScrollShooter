using UnityEngine;

/// <summary>
///  ласс дл€ управлени€ движением игрока во врем€ катсцены.
/// </summary>
[RequireComponent(typeof(PlayerMovement))]
public class CutsceneInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    /// <summary>
    /// ”станавливает направление движени€ игрока.
    /// </summary>
    /// <param name="direction">Ќаправление движени€ по оси X (-1 дл€ влево, 1 дл€ вправо, 0 дл€ остановки).</param>
    private void SetMovement(float direction)
    {
        _playerMovement.SetMoveDirection(new Vector2(direction, 0));
    }

    /// <summary>
    /// «аставл€ет игрока двигатьс€ вправо.
    /// </summary>
    public void MoveRight()
    {
        SetMovement(1f);
    }

    /// <summary>
    /// «аставл€ет игрока двигатьс€ влево.
    /// </summary>
    public void MoveLeft()
    {
        SetMovement(-1f);
    }

    /// <summary>
    /// ќстанавливает движение игрока.
    /// </summary>
    public void Stop()
    {
        SetMovement(0f);
    }
}