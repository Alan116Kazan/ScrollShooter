using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage = 10f; // Урон, который наносит объект
    [SerializeField] private bool _destroyOnHit = true; // Нужно ли уничтожать объект после попадания
    [SerializeField] private LayerMask _groundLayer; // Слой, который считается "Ground"

    // Событие, которое срабатывает при столкновении с чем-то
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, что объект, с которым произошло столкновение, имеет тег "Damageable"
        if (collision.CompareTag("Damageable"))
        {
            // Получаем компонент Health у объекта
            Health targetHealth = collision.GetComponent<Health>();

            // Если компонент Health найден, наносим урон
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(_damage);
            }

            // Если настроено уничтожение объекта, то уничтожаем его
            if (_destroyOnHit)
            {
                Destroy(gameObject);
            }
        }

        // Проверяем, является ли объект частью слоя "Ground"
        if (_groundLayer == (_groundLayer | (1 << collision.gameObject.layer)))
        {
            if (_destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}