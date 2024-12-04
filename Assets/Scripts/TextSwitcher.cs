using UnityEngine;
using UnityEngine.UI;

public class TextSwitcher : MonoBehaviour
{
    [SerializeField] private Text displayText;

    private int currentIndex = 0;

    
    private readonly string[] texts =
    {
        "������ �����",
        "������ �����",
        "������ �����",
        "��������� �����"
    };

    public void SwitchText()
    {
        if (displayText == null) return;

        displayText.text = texts[currentIndex];

        currentIndex = (currentIndex + 1) % texts.Length;
    }
}
