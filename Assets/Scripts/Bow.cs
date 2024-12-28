using UnityEngine;

/// <summary>
/// Класс, управляющий стрельбой из лука.
/// </summary>
public class Bow : MonoBehaviour
{
    [Header("Настройки стрелы")]
    [Tooltip("Префаб стрелы, который будет создан при выстреле.")]
    [SerializeField] private GameObject _arrowPrefab;

    [Tooltip("Точка, из которой производится выстрел.")]
    [SerializeField] private Transform _shootPoint;

    [Tooltip("Скорость полета стрелы.")]
    [SerializeField] private float _arrowSpeed = 10f;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateShootPointPosition();
    }

    /// <summary>
    /// Производит выстрел стрелой.
    /// </summary>
    public void Shoot()
    {
        if (_arrowPrefab == null || _shootPoint == null)
        {
            Debug.LogWarning("Не назначены префаб стрелы или точка выстрела.", this);
            return;
        }

        GameObject arrow = CreateArrow();
        SetArrowVelocity(arrow);
        AdjustArrowOrientation(arrow);
    }

    /// <summary>
    /// Обновляет позицию точки выстрела в зависимости от направления персонажа.
    /// </summary>
    private void UpdateShootPointPosition()
    {
        if (_shootPoint == null) return;

        float xOffset = Mathf.Abs(_shootPoint.localPosition.x);
        _shootPoint.localPosition = new Vector3(
            _spriteRenderer.flipX ? -xOffset : xOffset,
            _shootPoint.localPosition.y,
            _shootPoint.localPosition.z
        );
    }

    /// <summary>
    /// Создает стрелу на позиции точки выстрела.
    /// </summary>
    /// <returns>Созданный объект стрелы.</returns>
    private GameObject CreateArrow()
    {
        return Instantiate(_arrowPrefab, _shootPoint.position, Quaternion.identity);
    }

    /// <summary>
    /// Устанавливает скорость и направление полета стрелы.
    /// </summary>
    /// <param name="arrow">Объект стрелы.</param>
    private void SetArrowVelocity(GameObject arrow)
    {
        Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
        if (arrowRb == null)
        {
            Debug.LogWarning("Стрела не содержит Rigidbody2D.", arrow);
            return;
        }

        float direction = _spriteRenderer.flipX ? -1f : 1f;
        arrowRb.velocity = new Vector2(_arrowSpeed * direction, 0f);
    }

    /// <summary>
    /// Настраивает ориентацию стрелы в зависимости от направления выстрела.
    /// </summary>
    /// <param name="arrow">Объект стрелы.</param>
    private void AdjustArrowOrientation(GameObject arrow)
    {
        if (_spriteRenderer.flipX)
        {
            Vector3 arrowScale = arrow.transform.localScale;
            arrowScale.x = -Mathf.Abs(arrowScale.x);
            arrow.transform.localScale = arrowScale;
        }
    }
}