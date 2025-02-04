using UnityEngine;

/// <summary>
/// Класс, который управляет сундуком с аптечкой
/// </summary>
public class ChestController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _healAmount;
    [SerializeField] private LayerMask _playerLayer;

    [Header("References")]
    [SerializeField] private InstructionPanel _instructionPanel;
    [SerializeField] private ParticleSystem _chestOpenEffect;

    private ChestAnimation _chestAnimation;
    private Health _playerHealth;
    private bool _isPlayerInZone;

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
            _playerHealth = collision.GetComponent<Health>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            _instructionPanel.HideInstruction();
            _isPlayerInZone = false;
            _playerHealth = null;
        }
    }

    private void OpenChest()
    {
        _chestAnimation?.ChestOpen();
        _instructionPanel.HideInstruction();
        _playerHealth?.Heal(_healAmount);
        _chestOpenEffect?.Play();
    }

    private bool IsPlayer(GameObject obj)
    {
        return (_playerLayer & (1 << obj.layer)) != 0;
    }
}