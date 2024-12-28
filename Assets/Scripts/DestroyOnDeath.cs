using UnityEngine;
using System.Collections;

/// <summary>
/// Класс для управления уничтожением объекта после смерти.
/// Удаляет объект через определенную задержку после смерти.
/// </summary>
[RequireComponent(typeof(Death))]
public class DestroyOnDeath : MonoBehaviour
{
    private Death _death;

    private void Awake()
    {
        _death = GetComponent<Death>();
    }

    private void OnEnable()
    {
        // Подписываемся на событие смерти
        _death.OnDeathEvent += HandleDeath;
    }

    private void OnDisable()
    {
        // Отписываемся от события смерти при отключении объекта
        _death.OnDeathEvent -= HandleDeath;
    }

    /// <summary>
    /// Обработчик события смерти: инициирует удаление объекта.
    /// </summary>
    private void HandleDeath()
    {
        // Запускаем корутину для удаления объекта через 2 секунды после смерти
        StartCoroutine(DestroyAfterDelay(2f));
    }

    /// <summary>
    /// Уничтожает объект через заданную задержку.
    /// </summary>
    /// <param name="delay">Время задержки в секундах.</param>
    private IEnumerator DestroyAfterDelay(float delay)
    {
        // Ждем заданное количество времени перед уничтожением объекта
        yield return new WaitForSeconds(delay);

        // Удаляем объект
        Destroy(gameObject);
    }
}