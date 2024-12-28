using UnityEngine;
using System;

/// <summary>
/// �����, ���������� �� ��������� ������ ������� � ���������� ���������� ���������.
/// </summary>
[RequireComponent(typeof(Health))]
public class Death : MonoBehaviour
{
    /// <summary>
    /// �������, ������� ���������� ��� ������ �������.
    /// </summary>
    public event Action OnDeathEvent;

    [Header("���������")]
    [Tooltip("������, ����������� ��������� �������, ������� ����� ��������� ��� ������.")]
    [SerializeField] private MonoBehaviour _movementScript;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();

        // ������������� �� ������� ������ �� ���������� ��������
        _health.OnDeath += HandleDeath;
    }

    /// <summary>
    /// ������������ ������ �������.
    /// </summary>
    private void HandleDeath()
    {
        // ��������� ������ ��������, ���� �� ������
        if (_movementScript != null)
        {
            _movementScript.enabled = false;
        }

        // �������� ������� ������
        OnDeathEvent?.Invoke();
    }

    /// <summary>
    /// �������� ���������� ��������� �������.
    /// </summary>
    public void EnableMovement()
    {
        // �������� ��������, ���� ������ ������������
        if (_movementScript != null)
        {
            _movementScript.enabled = true;
        }
    }

    private void OnDestroy()
    {
        // ������������ �� ������� ������
        _health.OnDeath -= HandleDeath;
    }
}