using UnityEngine;

/// <summary>
/// Класс, который управляет сундуком с очками
/// </summary>
public class ChestController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask _playerLayer;

    [Header("References")]
    [SerializeField] private InstructionPanel _instructionPanel;
    [SerializeField] private ParticleSystem _chestOpenEffect;

    private ChestAnimation _chestAnimation;
    private bool _isPlayerInZone;
    private int _points = 50;

    private void Awake()
    {
        _chestAnimation = GetComponent<ChestAnimation>();
    }

    private void Update()
    {
        if (_isPlayerInZone && Input.GetKeyDown(KeyCode.F))
        {
            OpenChest();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            _instructionPanel.ShowInstruction("Нажмите F чтобы открыть сундук");
            _isPlayerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            _instructionPanel.HideInstruction();
            _isPlayerInZone = false;
        }
    }

    private void OpenChest()
    {
        _chestAnimation?.ChestOpen();
        _instructionPanel.HideInstruction();
        ScoreManager.Instance.IncreaseScore(_points);
        _chestOpenEffect?.Play();
    }

    private bool IsPlayer(GameObject obj)
    {
        return (_playerLayer & (1 << obj.layer)) != 0;
    }
}