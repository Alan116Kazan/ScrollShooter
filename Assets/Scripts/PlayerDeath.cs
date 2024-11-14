using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerDeath : MonoBehaviour
{
    [Header("Death Settings")]
    [SerializeField] private GameObject _gameoverPanel;
    [SerializeField] private MonoBehaviour _movementScript;

    private Collider2D _collider;
    private Health _health;
    private bool _isDead = false;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _health = GetComponent<Health>();
        _health.OnDeath += HandleDeath;
    }

    private void HandleDeath()
    {
        if (_isDead) return;

        _isDead = true;

        if (_collider != null)
        {
            _collider.enabled = false;
        }

        if (_movementScript != null)
        {
            _movementScript.enabled = false;
        }

        if (_gameoverPanel != null)
        {
            _gameoverPanel.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        _health.OnDeath -= HandleDeath;
    }
}