using UnityEngine;
using UnityEngine.UI;

public class TextSwitcher : MonoBehaviour
{
    [Header("UI Text Component")]
    [SerializeField] private Text displayText; // ������ �� ��������� Text ��� ����������� ������

    private int currentIndex = 0;

    // ������ ������� ��� ������������
    private readonly string[] texts =
    {
        "������ �����",
        "������ �����",
        "������ �����",
        "��������� �����"
    };

    // ����� ��� ������������ ������
    public void SwitchText()
    {
        // ���� displayText �� ��������, ������� �� ������
        if (displayText == null)
        {
            Debug.LogWarning("����� �� ��������");
            return;
        }

        // ���������, ��� ������ texts �� ������
        if (texts.Length == 0)
        {
            Debug.LogWarning("������ ������ ������.");
            return;
        }

        // ������������� ����� �� ������ �������� �������
        displayText.text = texts[currentIndex];

        // ��������� ������ ��� ���������� ������
        currentIndex = (currentIndex + 1) % texts.Length;
    }
}