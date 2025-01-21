using UnityEngine;

/// <summary>
/// Класс, который управляет актевирует и деактивирует универсальную панель с инструкциями
/// </summary>
public class InstructionTrigger : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask _playerLayer;

    [Header("References")]
    [SerializeField] private InstructionPanel _instructionPanel;
    [SerializeField] private string _instructionMessage = " ";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            _instructionPanel.ShowInstruction(_instructionMessage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            _instructionPanel.HideInstruction();
        }
    }

    private bool IsPlayer(GameObject obj)
    {
        return (_playerLayer & (1 << obj.layer)) != 0;
    }
}
