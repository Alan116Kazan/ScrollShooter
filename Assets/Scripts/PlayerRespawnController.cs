using UnityEngine;

/// <summary>
/// �����, ���������� �� ���������� ������������ ������ � ����������� ������ Game Over.
/// </summary>
[RequireComponent(typeof(Death))]
[RequireComponent(typeof(Health))]
public class PlayerRespawnController : MonoBehaviour
{
    [Header("������ Game Over")]
    [Tooltip("������, ������� ������������ ��� ������ ������.")]
    [SerializeField] private GameObject _gameOverPanel;

    private Death _playerDeath;
    private Health _playerHealth;
    private ArcherAnimations _archerAnimations;

    private void Awake()
    {
        _playerDeath = GetComponent<Death>();
        _playerHealth = GetComponent<Health>();
        _archerAnimations = GetComponent<ArcherAnimations>();

        // ������������� �� ������� ������ ������
        _playerDeath.OnDeathEvent += ShowGameOverPanel;
    }

    private void OnDestroy()
    {
        // ������������ �� ������� ������ ������
        _playerDeath.OnDeathEvent -= ShowGameOverPanel;
    }

    /// <summary>
    /// ���������� ������ Game Over.
    /// </summary>
    private void ShowGameOverPanel()
    {
        _gameOverPanel?.SetActive(true);
    }

    /// <summary>
    /// ������������ ������� �� ������ �����������.
    /// </summary>
    public void OnRespawnButtonClicked()
    {
        RespawnAtCheckpoint();
        _playerDeath.EnableMovement(); // ���������� ����������� ��������
        _archerAnimations.LandedOff();
    }

    /// <summary>
    /// ���������� ������ � �������� ����� ����������� � ��������������� ��������.
    /// </summary>
    private void RespawnAtCheckpoint()
    {
        // �������� ������� ��������� ���������
        Vector2 respawnPosition = CheckpointManager.Instance.GetActiveCheckpointPosition();

        // ���� �������� �������
        if (respawnPosition != Vector2.zero)
        {
            // ���������� ������ � ���������
            transform.position = respawnPosition;

            // ��������������� �������� ������
            _playerHealth.Heal(_playerHealth.MaxHealth);

            // �������� ������ Game Over
            _gameOverPanel?.SetActive(false);
        }
    }
}