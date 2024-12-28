using UnityEngine;

/// <summary>
/// Класс, который управляет взаимодействием аптечки с объектами, восстанавливая их здоровье при столкновении.
/// </summary>
public class FirstAidKit : MonoBehaviour
{
    [Header("Healing Settings")]
    [Tooltip("Количество здоровья, которое восстанавливает аптечка.")]
    [SerializeField] private int _healAmount;

    /// <summary>
    /// Обрабатывает столкновение с объектами. Если объект имеет компонент здоровья, восстанавливает его здоровье.
    /// </summary>
    /// <param name="collision">Коллайдер, с которым произошел контакт.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Получаем компонент Health у объекта, с которым столкнулась аптечка
        Health targetHealth = collision.GetComponent<Health>();

        // Если компонент здоровья найден, восстанавливаем здоровье и уничтожаем аптечку
        if (targetHealth != null)
        {
            targetHealth.Heal(_healAmount);
            Destroy(gameObject);  // Уничтожаем аптечку после использования
        }
    }
}