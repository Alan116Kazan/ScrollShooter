using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// ����� ��� ���������� ��������� ������������� �� ������ �������� ������.
/// </summary>
[RequireComponent(typeof(Health))]
public class HealthPostProcess : MonoBehaviour
{
    [Header("���������")]
    [SerializeField] private PostProcessVolume _postProcessVolume;

    private Health _playerHealth;
    private ChromaticAberration _chromaticAberration;
    private Vignette _vignette;

    private const float VignettePulseAmplitude = 0.1f;
    private const float HeartbeatSpeed = 2f;
    private const float LowHealthThreshold = 30f;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();

        if (_postProcessVolume == null || _postProcessVolume.profile == null)
        {
            Debug.LogError("PostProcessVolume ��� ��� ������� �� �������� � HealthPostProcess.");
            enabled = false;
            return;
        }

        // �������� ��������� �������������
        if (!_postProcessVolume.profile.TryGetSettings(out _chromaticAberration))
        {
            Debug.LogWarning("Chromatic Aberration �� ������ � ������� PostProcessVolume.");
        }

        if (!_postProcessVolume.profile.TryGetSettings(out _vignette))
        {
            Debug.LogWarning("Vignette �� ������� � ������� PostProcessVolume.");
        }
    }

    private void Update()
    {
        ApplyPostProcessingEffects();
    }

    /// <summary>
    /// ��������� ������� ������������� � ����������� �� �������� ������.
    /// </summary>
    private void ApplyPostProcessingEffects()
    {
        if (_playerHealth == null || _chromaticAberration == null || _vignette == null)
            return;

        bool isLowHealth = _playerHealth.CurrentHealth < LowHealthThreshold;

        // ��������� ������������� ���������
        _chromaticAberration.intensity.value = isLowHealth ? 1f : 0f;

        // ��������� ��������
        _vignette.intensity.value = isLowHealth
            ? 0.3f + Mathf.Sin(Time.time * HeartbeatSpeed) * 0.5f * VignettePulseAmplitude
            : 0f;
    }
}