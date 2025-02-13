using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    [Header("UI Элементы")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button muteButton;

    [Header("AudioMixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Графика кнопки")]
    [SerializeField] private Image muteButtonImage;  // UI Image на кнопке
    [SerializeField] private Sprite soundOnSprite;   // Иконка звука включена
    [SerializeField] private Sprite soundOffSprite;  // Иконка звука выключена

    private bool isMuted = false;
    private float previousVolume;

    private const float minVolumeDb = -80f; // минимум
    private const float maxVolumeDb = 0f;   // максимум

    private void Start()
    {
        // Инициализируем ползунок
        volumeSlider.minValue = minVolumeDb;
        volumeSlider.maxValue = maxVolumeDb;

        // Получаем текущее значение громкости из AudioMixer
        if (audioMixer.GetFloat("Volume", out float currentVolume))
        {
            volumeSlider.value = currentVolume;
        }
        else
        {
            volumeSlider.value = maxVolumeDb;
            audioMixer.SetFloat("Volume", maxVolumeDb);
        }

        // Подписываемся на события
        volumeSlider.onValueChanged.AddListener(SetVolume);
        muteButton.onClick.AddListener(ToggleMute);
    }

    /// <summary>
    /// Устанавливает громкость AudioMixer в зависимости от положения ползунка
    /// </summary>
    public void SetVolume(float volume)
    {
        if (!isMuted)
        {
            audioMixer.SetFloat("Volume", volume);
        }
    }

    /// <summary>
    /// Переключает состояние звука (включено/выключено)
    /// </summary>
    public void ToggleMute()
    {
        if (isMuted)
        {
            audioMixer.SetFloat("Volume", previousVolume);
            volumeSlider.value = previousVolume;
            muteButtonImage.sprite = soundOnSprite; // Меняем иконку на "звук включен"
            isMuted = false;
        }
        else
        {
            audioMixer.GetFloat("Volume", out previousVolume);
            audioMixer.SetFloat("Volume", minVolumeDb);
            volumeSlider.value = minVolumeDb;
            muteButtonImage.sprite = soundOffSprite; // Меняем иконку на "звук выключен"
            isMuted = true;
        }
    }
}