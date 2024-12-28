using UnityEngine;

/// <summary>
/// Этот класс представляет контрольную точку в игре.
/// </summary>
public class Checkpoint : MonoBehaviour
{
    [Header("Checkpoint Settings")]
    [SerializeField] private string playerLayerName = "Player";

    /// <summary>
    /// Обработчик события при вхождении игрока в триггер контрольной точки.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверка, что в триггер вошел объект с нужным слоем (Player)
        if (collision.gameObject.layer == LayerMask.NameToLayer(playerLayerName))
        {
            // Устанавливаем эту контрольную точку как активную
            CheckpointManager.Instance.SetActiveCheckpoint(this);
        }
    }
}