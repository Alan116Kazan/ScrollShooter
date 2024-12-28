using UnityEngine;

/// <summary>
/// Управляет системой контрольных точек (чекпоинтов) в игре.
/// </summary>
public class CheckpointManager : MonoBehaviour
{
    /// <summary>
    /// Единственный экземпляр CheckpointManager.
    /// </summary>
    public static CheckpointManager Instance { get; private set; }

    /// <summary>
    /// Текущая активная контрольная точка.
    /// </summary>
    private Checkpoint _activeCheckpoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Устанавливает активную контрольную точку.
    /// </summary>
    /// <param name="checkpoint">Контрольная точка, которую нужно сделать активной.</param>
    public void SetActiveCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoint != null)
        {
            _activeCheckpoint = checkpoint;
            Debug.Log($"Активный чекпоинт установлен: {checkpoint.name}");
        }
    }

    /// <summary>
    /// Возвращает позицию текущей активной контрольной точки.
    /// </summary>
    public Vector2 GetActiveCheckpointPosition()
    {
        if (_activeCheckpoint != null)
        {
            return _activeCheckpoint.transform.position;
        }
        else
        {
            Debug.LogWarning("Активный чекпоинт не установлен");
            return Vector2.zero;
        }
    }
}