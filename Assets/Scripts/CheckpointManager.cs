using UnityEngine;

/// <summary>
/// ��������� �������� ����������� ����� (����������) � ����.
/// </summary>
public class CheckpointManager : MonoBehaviour
{
    /// <summary>
    /// ������������ ��������� CheckpointManager.
    /// </summary>
    public static CheckpointManager Instance { get; private set; }

    /// <summary>
    /// ������� �������� ����������� �����.
    /// </summary>
    private Checkpoint _activeCheckpoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ������������� �������� ����������� �����.
    /// </summary>
    /// <param name="checkpoint">����������� �����, ������� ����� ������� ��������.</param>
    public void SetActiveCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoint != null)
        {
            _activeCheckpoint = checkpoint;
            Debug.Log($"�������� �������� ����������: {checkpoint.name}");
        }
    }

    /// <summary>
    /// ���������� ������� ������� �������� ����������� �����.
    /// </summary>
    public Vector2 GetActiveCheckpointPosition()
    {
        if (_activeCheckpoint != null)
        {
            return _activeCheckpoint.transform.position;
        }
        else
        {
            Debug.LogWarning("�������� �������� �� ����������");
            return Vector2.zero;
        }
    }
}