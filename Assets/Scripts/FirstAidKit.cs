using UnityEngine;

/// <summary>
/// �����, ������� ��������� ��������������� ������� � ���������, �������������� �� �������� ��� ������������.
/// </summary>
public class FirstAidKit : MonoBehaviour
{
    [Header("Healing Settings")]
    [Tooltip("���������� ��������, ������� ��������������� �������.")]
    [SerializeField] private int _healAmount;

    /// <summary>
    /// ������������ ������������ � ���������. ���� ������ ����� ��������� ��������, ��������������� ��� ��������.
    /// </summary>
    /// <param name="collision">���������, � ������� ��������� �������.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �������� ��������� Health � �������, � ������� ����������� �������
        Health targetHealth = collision.GetComponent<Health>();

        // ���� ��������� �������� ������, ��������������� �������� � ���������� �������
        if (targetHealth != null)
        {
            targetHealth.Heal(_healAmount);
            Destroy(gameObject);  // ���������� ������� ����� �������������
        }
    }
}