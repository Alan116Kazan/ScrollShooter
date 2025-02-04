using UnityEngine;

/// <summary>
/// Класс, отвечающий за управление возрождением игрока и отображение экрана Game Over.
/// </summary>
[RequireComponent(typeof(Death))]
[RequireComponent(typeof(Health))]
public class PlayerRespawnController : MonoBehaviour
{
    [Header("Панель Game Over")]
    [Tooltip("Панель, которая отображается при смерти игрока.")]
    [SerializeField] private GameObject _gameOverPanel;

    private Death _playerDeath;
    private Health _playerHealth;
    private ArcherAnimations _archerAnimations;

    private void Awake()
    {
        _playerDeath = GetComponent<Death>();
        _playerHealth = GetComponent<Health>();
        _archerAnimations = GetComponent<ArcherAnimations>();

        // Подписываемся на событие смерти игрока
        _playerDeath.OnDeathEvent += ShowGameOverPanel;
    }

    private void OnDestroy()
    {
        // Отписываемся от события смерти игрока
        _playerDeath.OnDeathEvent -= ShowGameOverPanel;
    }

    /// <summary>
    /// Показывает панель Game Over.
    /// </summary>
    private void ShowGameOverPanel()
    {
        _gameOverPanel?.SetActive(true);
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку возрождения.
    /// </summary>
    public void OnRespawnButtonClicked()
    {
        RespawnAtCheckpoint();
        _playerDeath.EnableMovement(); // Возвращает возможность движения
        _archerAnimations.LandedOff();
    }

    /// <summary>
    /// Перемещает игрока к активной точке возрождения и восстанавливает здоровье.
    /// </summary>
    private void RespawnAtCheckpoint()
    {
        // Получаем позицию активного чекпоинта
        Vector2 respawnPosition = CheckpointManager.Instance.GetActiveCheckpointPosition();

        // Если чекпоинт активен
        if (respawnPosition != Vector2.zero)
        {
            // Перемещаем игрока к чекпоинту
            transform.position = respawnPosition;

            // Восстанавливаем здоровье игрока
            _playerHealth.Heal(_playerHealth.MaxHealth);

            // Скрываем панель Game Over
            _gameOverPanel?.SetActive(false);
        }
    }
}