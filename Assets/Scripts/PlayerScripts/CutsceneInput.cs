using UnityEngine;

public class CutsceneInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void SetMovement(float direction)
    {
        _playerMovement.SetMoveDirection(new Vector2(direction, 0));
    }

    public void MoveRight()
    {
        SetMovement(1f);
    }

    public void MoveLeft()
    {
        SetMovement(-1f);
    }

    public void Stop()
    {
        SetMovement(0f);
    }
}
