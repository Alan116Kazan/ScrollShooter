using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Универсальная панель с инструкциями
/// </summary>
public class InstructionPanel : MonoBehaviour
{
    [SerializeField] private Text _instructionText;

    public void ShowInstruction(string message)
    {
        _instructionText.text = message;
        gameObject.SetActive(true);
    }

    public void HideInstruction()
    {
        gameObject.SetActive(false);
    }
}