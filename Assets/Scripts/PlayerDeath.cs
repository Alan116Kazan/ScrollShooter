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

        // �������� �� ������� ������, ���� ��� ��������� � Health
        _health.OnDeath += HandleDeath;
    }

    private void HandleDeath()
    {
        if (_isDead) return;  // ������ �� ���������� ������
        _isDead = true;

        _playerMovement.enabled = false;
        _gameoverPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        // ������������ �� ������� ��� ����������� �������
        _health.OnDeath -= HandleDeath;
    }
}
