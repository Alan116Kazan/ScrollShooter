using UnityEngine;

/// <summary>
/// Класс, отвечающий за преследование игрока врагом.
/// </summary>
[RequireComponent(typeof(EnemyPatrol))]
[RequireComponent(typeof(EnemyController))]
public class EnemyChase : MonoBehaviour
{
    [Header("Настройки движения")]
    [Tooltip("Ссылка на объект игрока.")]
    [SerializeField] private Transform _player;

    [Tooltip("Скорость преследования.")]
    [SerializeField] private float _moveSpeed = 5f;

    [Tooltip("Ускорение для плавного изменения скорости.")]
    [SerializeField] private float _acceleration = 10f;

    private EnemyPatrol _enemyPatrol;
    private EnemyController _enemyController;

    private void Awake()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyController = GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        if (_player != null)
        {
            Rigidbody2D rb = _enemyController.Rb;

            // Рассчитываем направление движения к игроку
            Vector2 direction = (_player.position - transform.position).normalized;

            // Cкорость врага
            Vector2 targetVelocity = direction * _moveSpeed;

            // Плавное изменение текущей скорости
            Vector2 velocity = Vector2.Lerp(rb.velocity, targetVelocity, _acceleration * Time.fixedDeltaTime);

            // Применяем рассчитанную скорость
            rb.velocity = new Vector2(velocity.x, rb.velocity.y);

            // Поворачиваем врага в сторону игрока
            HandleFlip(direction.x);
        }
    }

    /// <summary>
    /// Обрабатывает поворот врага в сторону игрока.
    /// </summary>
    /// <param name="directionX">Значение по оси X, указывающее направление к игроку.</param>
    private void HandleFlip(float directionX)
    {
        // Если направление X противоположно текущему направлению врага, выполняем поворот
        if (Mathf.Sign(directionX) != Mathf.Sign(transform.localScale.x))
        {
            _enemyPatrol.Flip(); // Поворачиваем
        }
    }
}