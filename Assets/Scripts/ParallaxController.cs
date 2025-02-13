using UnityEngine;

/// <summary>
/// Управляет параллакс-эффектом для фона.
/// </summary>
public class ParallaxController : MonoBehaviour
{
    [Header("Настройки слоев")]
    [Tooltip("Слои, которые участвуют в параллаксе.")]
    [SerializeField] private Transform[] _layers;

    [Tooltip("Коэффициенты параллакса для каждого слоя.")]
    [SerializeField] private float[] _coefficients;

    private Vector3[] _initialPositions;
    private int _layersCount;

    void Start()
    {
        _layersCount = _layers.Length;
        _initialPositions = new Vector3[_layersCount];

        // Сохраняем начальные позиции каждого слоя
        for (int i = 0; i < _layersCount; i++)
        {
            _initialPositions[i] = _layers[i].position;
        }
    }

    void LateUpdate()
    {
        ApplyParallaxEffect();
    }

    /// <summary>
    /// Применяет параллакс-эффект к слоям.
    /// </summary>
    private void ApplyParallaxEffect()
    {
        Vector3 cameraPosition = transform.position;

        for (int i = 0; i < _layersCount; i++)
        {
            _layers[i].position = _initialPositions[i] + cameraPosition * _coefficients[i];
        }
    }
}