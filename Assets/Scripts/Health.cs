using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    private bool _isAlive;

    public bool IsAlive => _isAlive;

    public event UnityAction OnDeath;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        if (!_isAlive) return;

        _currentHealth -= damage;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (_currentHealth <= 0 && _isAlive)
        {
            _isAlive = false;
            OnDeath?.Invoke();
        }
    }

    public void RestoreHealth(float amount)
    {
        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
        if (_currentHealth > 0)
        {
            _isAlive = true; // Возвращаем персонажа к жизни, если его здоровье восстановлено
        }
    }
}