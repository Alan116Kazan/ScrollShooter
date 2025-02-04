using UnityEngine;

public class SpriteColorChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Color _startColor = Color.white; // Начальный цвет
    [SerializeField] private Color _targetColor = Color.red;  // Цвет, на который будем менять
    [SerializeField] private float _duration = 2f;            // Длительность цикла смены цвета

    private float _time;
    private bool _isReversing;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogError("На объекте отсутствует SpriteRenderer!");
            enabled = false;
        }
    }

    private void Update()
    {
        if (_spriteRenderer != null)
        {
            // Увеличиваем или уменьшаем время в зависимости от направления
            _time += (_isReversing ? -1 : 1) * Time.deltaTime / _duration;

            // Ограничиваем значение time от 0 до 1
            if (_time >= 1f)
            {
                _time = 1f;
                _isReversing = true; // Меняем направление
            }
            else if (_time <= 0f)
            {
                _time = 0f;
                _isReversing = false; // Меняем направление
            }

            // Меняем цвет
            _spriteRenderer.color = Color.Lerp(_startColor, _targetColor, _time);
        }
    }
}
