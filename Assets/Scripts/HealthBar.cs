using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����� ��� ���������� ������������ ������ �������� ������.
/// </summary>
public class HealthBar : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("��������� ���� ��� ����������� �������� �������� ������.")]
    [SerializeField] private Text _hpText;

    [Tooltip("��������� �������� ������, �� �������� ������� ������� HP.")]
    [SerializeField] private Health _healthComponent;

    [Tooltip("������ �������� ������.")]
    [SerializeField] private Image _healthBarImage;

    private void Update()
    {
        DisplayHpNum();
        UpdateHealthBar();
    }

    /// <summary>
    /// ���������� ������� ���������� �������� ������ � ���� ������.
    /// </summary>
    private void DisplayHpNum()
    {
        // �������� �� ������� ���������� ���������� ��� �����������
        if (_hpText != null && _healthComponent != null)
        {
            _hpText.text = _healthComponent.CurrentHealth.ToString();
        }
    }

    /// <summary>
    /// ��������� ���������� ����������� ������ ��������.
    /// </summary>
    private void UpdateHealthBar()
    {
        // �������� �� ������� ���������� ����������� ��� ������ ��������
        if (_healthBarImage != null && _healthComponent != null)
        {
            // ������������ ������� �������� � ��������� ���������� ������
            float healthPercentage = _healthComponent.CurrentHealth / _healthComponent.MaxHealth;
            _healthBarImage.fillAmount = Mathf.Clamp01(healthPercentage); // ������������ �������� �� 0 �� 1
        }
    }
}