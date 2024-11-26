using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Text _hpText;
    [SerializeField] private Health _healthComponent;
    [SerializeField] private Image _healthBarImage;


    private void Update()
    {
        DisplayHpNum();
        UpdateHealthBar();
    }

    private void DisplayHpNum()
    {
        if (_hpText != null)
        {
            _hpText.text = _healthComponent.CurrentHealth.ToString();
        }
    }

    private void UpdateHealthBar()
    {
        float result = _healthComponent.CurrentHealth / _healthComponent.MaxHealth;
        _healthBarImage.fillAmount = result;

    }
}