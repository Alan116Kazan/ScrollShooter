using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public bool IsAlive => _currentHealth > 0;

    public float CurrentHealth => _currentHealth;

    // ������������ ��������
    public float MaxHealth => _maxHealth;

    // �������, ���������� ��� ������
    public event UnityAction OnDeath;

    private void Awake()
    {
        // ������������� ��������� �������� ��������
        _currentHealth = _maxHealth;
    }

    /// <summary>
    /// ����� ��������� �����
    /// </summary>
    /// <param name="damage">���������� �����</param>
    public void TakeDamage(float damage)
    {
        if (damage <= 0) return; // ���������� ������������� �������� ����� ��� ����

        _currentHealth -= damage;

        // ��������, �� ���� �� ������
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDeath?.Invoke(); // �������� ������� ������
        }
    }

    /// <summary>
    /// ����� ��� �������
    /// </summary>
    /// <param name="amount">���������� �������</param>
    public void Heal(float amount)
    {
        if (amount <= 0) return; // ���������� ������������� �������� ������� ��� ����

        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth); // ����� �� ������������� ��������
    }
}