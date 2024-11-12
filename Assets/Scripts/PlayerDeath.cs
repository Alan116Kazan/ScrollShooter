using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerDeath : MonoBehaviour
{
    [Header("Death Settings")]
    [SerializeField] private GameObject _gameoverPanel;

    private Health _health;
    private PlayerMovement _playerMovement;
    private bool _isDead = false;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _playerMovement = GetComponent<PlayerMovement>();

        // Подписка на событие смерти, если оно добавлено в Health
        _health.OnDeath += HandleDeath;
    }

    private void HandleDeath()
    {
        if (_isDead) return;  // Защита от повторного вызова
        _isDead = true;

        _playerMovement.enabled = false;
        _gameoverPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        _health.OnDeath -= HandleDeath;
    }
}
