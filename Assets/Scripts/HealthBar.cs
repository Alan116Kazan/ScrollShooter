using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс для управления отображением панели здоровья игрока.
/// </summary>
public class HealthBar : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("Текстовое поле для отображения текущего здоровья игрока.")]
    [SerializeField] private Text _hpText;

    [Tooltip("Компонент здоровья игрока, от которого зависит текущий HP.")]
    [SerializeField] private Health _healthComponent;

    [Tooltip("Полоса здоровья игрока.")]
    [SerializeField] private Image _healthBarImage;

    private void Update()
    {
        DisplayHpNum();
        UpdateHealthBar();
    }

    /// <summary>
    /// Отображает текущее количество здоровья игрока в виде текста.
    /// </summary>
    private void DisplayHpNum()
    {
        // Проверка на наличие текстового компонента для отображения
        if (_hpText != null && _healthComponent != null)
        {
            _hpText.text = _healthComponent.CurrentHealth.ToString();
        }
    }

    /// <summary>
    /// Обновляет визуальное отображение полосы здоровья.
    /// </summary>
    private void UpdateHealthBar()
    {
        // Проверка на наличие компонента изображения для полосы здоровья
        if (_healthBarImage != null && _healthComponent != null)
        {
            // Рассчитываем процент здоровья и обновляем заполнение полосы
            float healthPercentage = _healthComponent.CurrentHealth / _healthComponent.MaxHealth;
            _healthBarImage.fillAmount = Mathf.Clamp01(healthPercentage); // Ограничиваем значение от 0 до 1
        }
    }
}