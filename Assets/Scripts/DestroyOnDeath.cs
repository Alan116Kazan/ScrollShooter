using UnityEngine;
using System.Collections;

/// <summary>
/// Удаляет объект после смерти с задержкой и начисляет очки.
/// </summary>
[RequireComponent(typeof(Death))]
public class DestroyOnDeath : MonoBehaviour
{
    private Death _death;

    private int _points = 10; // Очки за уничтожение объекта

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
        // Отписываемся от события смерти
        _death.OnDeathEvent -= HandleDeath;
    }

    /// <summary>
    /// Вызывается при смерти объекта, начисляет очки и удаляет объект.
    /// </summary>
    private void HandleDeath()
    {
        ScoreManager.Instance.IncreaseScore(_points);
        StartCoroutine(DestroyAfterDelay(1f));
    }

    /// <summary>
    /// Удаляет объект через заданное время.
    /// </summary>
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}