using UnityEngine;
using System;

/// <summary>
/// Класс, отвечающий за обработку смерти объекта и управление связанными событиями.
/// </summary>
[RequireComponent(typeof(Health))]
public class Death : MonoBehaviour
{
    /// <summary>
    /// Событие, которое вызывается при смерти объекта.
    /// </summary>
    public event Action OnDeathEvent;

    [Header("Настройки")]
    [Tooltip("Скрипт, управляющий движением объекта, который нужно отключить при смерти.")]
    [SerializeField] private MonoBehaviour _movementScript;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();

        // Подписываемся на событие смерти из компонента здоровья
        _health.OnDeath += HandleDeath;
    }

    /// <summary>
    /// Обрабатывает смерть объекта.
    /// </summary>
    private void HandleDeath()
    {
        // Отключаем скрипт движения, если он указан
        if (_movementScript != null)
        {
            _movementScript.enabled = false;
        }

        // Вызываем событие смерти
        OnDeathEvent?.Invoke();
    }

    /// <summary>
    /// Включает управление движением объекта.
    /// </summary>
    public void EnableMovement()
    {
        // Включаем движение, если скрипт присутствует
        if (_movementScript != null)
        {
            _movementScript.enabled = true;
        }
    }

    private void OnDestroy()
    {
        // Отписываемся от события смерти
        _health.OnDeath -= HandleDeath;
    }
}