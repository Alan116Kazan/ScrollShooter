using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HealthPostProcess : MonoBehaviour
{
    [SerializeField] private Health _playerHealth; // Ссылка на компонент Health игрока
    [SerializeField] private PostProcessVolume _postProcessVolume; // Ссылка на PostProcessVolume

    private ChromaticAberration _chromaticAberration;
    private Vignette _vignette;

    private float _vignettePulseAmplitude = 0.1f;
    private float _heartbeatSpeed = 2f; // Скорость пульсации виньетки

    private void Start()
    {
        // Проверяем наличие необходимых компонентов
        if (_playerHealth == null)
        {
            Debug.LogError("PlayerHealth не назначен в инспекторе!");
            return;
        }

        if (_postProcessVolume == null)
        {
            Debug.LogError("PostProcessVolume не назначен в инспекторе!");
            return;
        }

        // Получаем компоненты Chromatic Aberration и Vignette из PostProcessVolume
        if (_postProcessVolume.profile.TryGetSettings(out _chromaticAberration))
        {
            _chromaticAberration.intensity.value = 0f;
        }
        else
        {
            Debug.LogWarning("Chromatic Aberration не настроен в профиле PostProcessVolume.");
        }

        if (_postProcessVolume.profile.TryGetSettings(out _vignette))
        {
            _vignette.intensity.value = 0f;
        }
        else
        {
            Debug.LogWarning("Vignette не настроен в профиле PostProcessVolume.");
        }
    }

    private void Update()
    {
        // Прекращаем выполнение, если ссылки или компоненты отсутствуют
        if (_playerHealth == null || _chromaticAberration == null || _vignette == null) return;

        // Проверяем здоровье и изменяем интенсивность Chromatic Aberration
        _chromaticAberration.intensity.value = _playerHealth.CurrentHealth < 30f ? 1f : 0f;

        // Если здоровье меньше 30, активируем пульсацию Vignette
        if (_playerHealth.CurrentHealth < 30f)
        {
            float pulse = Mathf.Sin(Time.time * _heartbeatSpeed) * 0.5f + 0.5f; // Генерация значения от 0 до 1
            _vignette.intensity.value = 0.3f + pulse * _vignettePulseAmplitude; // Пульсация от 0.3 до 0.4
        }
        else
        {
            _vignette.intensity.value = 0f; // Сбрасываем интенсивность в 0
        }
    }
}