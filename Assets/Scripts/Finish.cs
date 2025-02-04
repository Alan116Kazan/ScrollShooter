using UnityEngine;

/// <summary>
/// �����, ���������� �� ���������� ����
/// </summary>
public class FinishTrigger : MonoBehaviour
{
    [Tooltip("UI-������, ������� ������������ ��� ������������ � �������.")]
    [SerializeField] private GameObject _finishPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayerLayer(collision.gameObject.layer))
        {
            ActivateFinishPanel();
        }
    }

    private bool IsPlayerLayer(int layer)
    {
        return layer == LayerMask.NameToLayer("Player");
    }

    /// <summary>
    /// ���������� ������ ���������� ������.
    /// </summary>
    private void ActivateFinishPanel()
    {
        _finishPanel.SetActive(true);
    }
}
