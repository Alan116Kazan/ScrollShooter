using UnityEngine;

/// <summary>
/// ����� ��� ���������� ��������� ������ �� ����� ��������.
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

    /// <summary>
    /// �������� ���������� �������.
    /// </summary>
    public void PlayerInputOn()
    {
        if (_playerInput != null)
        {
            _playerInput.enabled = true;
        }
        else
        {
            Debug.LogWarning("PlayerInput ��������� ����������� �� �������.");
        }
    }

    /// <summary>
    /// ��������� ���������� �������.
    /// </summary>
    public void PlayerInputOff()
    {
        if (_playerInput != null)
        {
            _playerInput.enabled = false;
        }
        else
        {
            Debug.LogWarning("PlayerInput ��������� ����������� �� �������.");
        }
    }
}