using UnityEngine;
using System.Collections;

/// <summary>
/// Класс, отвечающий за патрулирование врага между двумя границами.
/// </summary>
[RequireComponent(typeof(EnemyController))]
public class EnemyPatrol : MonoBehaviour
{
    [Header("Границы патрулирования")]
    [Tooltip("Левая граница патрулирования.")]
    [SerializeField] private Transform _leftBoundary;

    [Tooltip("Правая граница патрулирования.")]
    [SerializeField] private Transform _rightBoundary;

    [Header("Настройки патрулирования")]
    [Tooltip("Скорость передвижения.")]
    [SerializeField] private float _speed = 2f;

    [Tooltip("Время ожидания перед разворотом.")]
    [SerializeField] private float _waitTime = 3f;

    private bool _movingRight = true;
    private bool _isWaiting = false;

    private EnemyController _enemyController;

    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        if (_isWaiting) return;

        Patrol();
    }

    /// <summary>
    /// Логика патрулирования между границами.
    /// </summary>
    private void Patrol()
    {
        // Получаем Rigidbody2D через EnemyController
        Rigidbody2D rb = _enemyController.Rb;

        if (_movingRight)
        {
            // Движение вправо
            rb.velocity = new Vector2(_speed, rb.velocity.y);

            // Поворот вправо, если требуется
            if (transform.localScale.x < 0)
                Flip();

            // Проверка достижения правой границы
            if (transform.position.x >= _rightBoundary.position.x)
                StartCoroutine(WaitAndTurn(false));
        }
        else
        {
            // Движение влево
            rb.velocity = new Vector2(-_speed, rb.velocity.y);

            // Поворот влево, если требуется
            if (transform.localScale.x > 0)
                Flip();

            // Проверка достижения левой границы
            if (transform.position.x <= _leftBoundary.position.x)
                StartCoroutine(WaitAndTurn(true));
        }
    }

    /// <summary>
    /// Поворот врага.
    /// </summary>
    public void Flip()
    {
        // Инвертируем масштаб по оси X для изменения направления
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    /// <summary>
    /// Ожидание перед разворотом.
    /// </summary>
    /// <param name="turnRight">Направление после ожидания: вправо или влево.</param>
    private IEnumerator WaitAndTurn(bool turnRight)
    {
        _isWaiting = true;

        // Останавливаем движение
        _enemyController.Rb.velocity = Vector2.zero;

        // Ждем указанное время
        yield return new WaitForSeconds(_waitTime);

        // Изменяем направление движения
        _movingRight = turnRight;
        _isWaiting = false;
    }
}