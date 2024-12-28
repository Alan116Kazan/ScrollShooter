using UnityEngine;

/// <summary>
/// ����� ��� ���������� ��������� ������ �� ����� ��������.
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
    /// ������������� ����������� �������� ������.
    /// </summary>
    /// <param name="direction">����������� �������� �� ��� X (-1 ��� �����, 1 ��� ������, 0 ��� ���������).</param>
    private void SetMovement(float direction)
    {
        _playerMovement.SetMoveDirection(new Vector2(direction, 0));
    }

    /// <summary>
    /// ���������� ������ ��������� ������.
    /// </summary>
    public void MoveRight()
    {
        SetMovement(1f);
    }

    /// <summary>
    /// ���������� ������ ��������� �����.
    /// </summary>
    public void MoveLeft()
    {
        SetMovement(-1f);
    }

    /// <summary>
    /// ������������� �������� ������.
    /// </summary>
    public void Stop()
    {
        SetMovement(0f);
    }
}