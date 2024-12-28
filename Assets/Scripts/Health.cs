using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public bool IsAlive => _currentHealth > 0;

    public float CurrentHealth => _currentHealth;

    // Максимальное здоровье
    public float MaxHealth => _maxHealth;

    // Событие, вызываемое при смерти
    public event UnityAction OnDeath;

    private void Awake()
    {
        // Устанавливаем начальное значение здоровья
        _currentHealth = _maxHealth;
    }

    /// <summary>
    /// Метод получения урона
    /// </summary>
    /// <param name="damage">Количество урона</param>
    public void TakeDamage(float damage)
    {
        if (damage <= 0) return; // Игнорируем отрицательные значения урона или ноль

        _currentHealth -= damage;

        // Проверка, не умер ли объект
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDeath?.Invoke(); // Вызываем событие смерти
        }
    }

    /// <summary>
    /// Метод для лечения
    /// </summary>
    /// <param name="amount">Количество лечения</param>
    public void Heal(float amount)
    {
        if (amount <= 0) return; // Игнорируем отрицательные значения лечения или ноль

        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth); // Лечим до максимального значения
    }
}