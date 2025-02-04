using UnityEngine;
using UnityEngine.UI;

public class TextSwitcher : MonoBehaviour
{
    [Header("UI Text Component")]
    [SerializeField] private Text displayText; // Ссылка на компонент Text для отображения текста

    private int currentIndex = 0;

    // Массив текстов для переключения
    private string[] texts =
    {
        "Разработчик\nАлан Фарниев",
        "Звукорежиссер\nАлан Фарниев",
        "Scroll Shooter"
    };

    // Метод для переключения текста
    public void SwitchText()
    {
        // Проверяем, что displayText назначен
        if (displayText == null)
        {
            Debug.LogWarning("Текст не назначен.");
            return;
        }

        // Проверяем, что массив texts не пуст
        if (texts.Length == 0)
        {
            Debug.LogWarning("Массив текста пустой.");
            return;
        }

        // Устанавливаем текст на основе текущего индекса
        displayText.text = texts[currentIndex];

        // Обновляем индекс для следующего текста
        currentIndex = (currentIndex + 1) % texts.Length;
    }
}