using UnityEngine;

/// <summary>
/// Класс, отвечающий за завершение игры
/// </summary>
public class FinishTrigger : MonoBehaviour
{
    [Tooltip("UI-панель, которая активируется при столкновении с игроком.")]
    [SerializeField] private GameObject _finishPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayerLayer(collision.gameObject.layer))
        {
            ActivateFinishPanel();
        }
    }

    private bool IsPlayerLayer(int layer)
    {
        return layer == LayerMask.NameToLayer("Player");
    }

    /// <summary>
    /// Активирует панель завершения уровня.
    /// </summary>
    private void ActivateFinishPanel()
    {
        _finishPanel.SetActive(true);
    }
}
