using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    [Header("UI ��������")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button muteButton;

    [Header("AudioMixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("������� ������")]
    [SerializeField] private Image muteButtonImage;  // UI Image �� ������
    [SerializeField] private Sprite soundOnSprite;   // ������ ����� ��������
    [SerializeField] private Sprite soundOffSprite;  // ������ ����� ���������

    private bool isMuted = false;
    private float previousVolume;

    private const float minVolumeDb = -80f; // �������
    private const float maxVolumeDb = 0f;   // ��������

    private void Start()
    {
        // �������������� ��������
        volumeSlider.minValue = minVolumeDb;
        volumeSlider.maxValue = maxVolumeDb;

        // �������� ������� �������� ��������� �� AudioMixer
        if (audioMixer.GetFloat("Volume", out float currentVolume))
        {
            volumeSlider.value = currentVolume;
        }
        else
        {
            volumeSlider.value = maxVolumeDb;
            audioMixer.SetFloat("Volume", maxVolumeDb);
        }

        // ������������� �� �������
        volumeSlider.onValueChanged.AddListener(SetVolume);
        muteButton.onClick.AddListener(ToggleMute);
    }

    /// <summary>
    /// ������������� ��������� AudioMixer � ����������� �� ��������� ��������
    /// </summary>
    public void SetVolume(float volume)
    {
        if (!isMuted)
        {
            audioMixer.SetFloat("Volume", volume);
        }
    }

    /// <summary>
    /// ����������� ��������� ����� (��������/���������)
    /// </summary>
    public void ToggleMute()
    {
        if (isMuted)
        {
            audioMixer.SetFloat("Volume", previousVolume);
            volumeSlider.value = previousVolume;
            muteButtonImage.sprite = soundOnSprite; // ������ ������ �� "���� �������"
            isMuted = false;
        }
        else
        {
            audioMixer.GetFloat("Volume", out previousVolume);
            audioMixer.SetFloat("Volume", minVolumeDb);
            volumeSlider.value = minVolumeDb;
            muteButtonImage.sprite = soundOffSprite; // ������ ������ �� "���� ��������"
            isMuted = true;
        }
    }
}