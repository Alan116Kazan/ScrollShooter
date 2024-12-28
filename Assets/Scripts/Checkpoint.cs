using UnityEngine;

/// <summary>
/// ���� ����� ������������ ����������� ����� � ����.
/// </summary>
public class Checkpoint : MonoBehaviour
{
    [Header("Checkpoint Settings")]
    [SerializeField] private string playerLayerName = "Player";

    /// <summary>
    /// ���������� ������� ��� ��������� ������ � ������� ����������� �����.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��������, ��� � ������� ����� ������ � ������ ����� (Player)
        if (collision.gameObject.layer == LayerMask.NameToLayer(playerLayerName))
        {
            // ������������� ��� ����������� ����� ��� ��������
            CheckpointManager.Instance.SetActiveCheckpoint(this);
        }
    }
}