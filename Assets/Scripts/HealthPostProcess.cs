using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HealthPostProcess : MonoBehaviour
{
    [SerializeField] private Health _playerHealth; // ������ �� ��������� Health ������
    [SerializeField] private PostProcessVolume _postProcessVolume; // ������ �� PostProcessVolume

    private ChromaticAberration _chromaticAberration;
    private Vignette _vignette;

    private float _vignettePulseAmplitude = 0.1f;
    private float _heartbeatSpeed = 2f; // �������� ��������� ��������

    private void Start()
    {
        // ��������� ������� ����������� �����������
        if (_playerHealth == null)
        {
            Debug.LogError("PlayerHealth �� �������� � ����������!");
            return;
        }

        if (_postProcessVolume == null)
        {
            Debug.LogError("PostProcessVolume �� �������� � ����������!");
            return;
        }

        // �������� ���������� Chromatic Aberration � Vignette �� PostProcessVolume
        if (_postProcessVolume.profile.TryGetSettings(out _chromaticAberration))
        {
            _chromaticAberration.intensity.value = 0f;
        }
        else
        {
            Debug.LogWarning("Chromatic Aberration �� �������� � ������� PostProcessVolume.");
        }

        if (_postProcessVolume.profile.TryGetSettings(out _vignette))
        {
            _vignette.intensity.value = 0f;
        }
        else
        {
            Debug.LogWarning("Vignette �� �������� � ������� PostProcessVolume.");
        }
    }

    private void Update()
    {
        // ���������� ����������, ���� ������ ��� ���������� �����������
        if (_playerHealth == null || _chromaticAberration == null || _vignette == null) return;

        // ��������� �������� � �������� ������������� Chromatic Aberration
        _chromaticAberration.intensity.value = _playerHealth.CurrentHealth < 30f ? 1f : 0f;

        // ���� �������� ������ 30, ���������� ��������� Vignette
        if (_playerHealth.CurrentHealth < 30f)
        {
            float pulse = Mathf.Sin(Time.time * _heartbeatSpeed) * 0.5f + 0.5f; // ��������� �������� �� 0 �� 1
            _vignette.intensity.value = 0.3f + pulse * _vignettePulseAmplitude; // ��������� �� 0.3 �� 0.4
        }
        else
        {
            _vignette.intensity.value = 0f; // ���������� ������������� � 0
        }
    }
}