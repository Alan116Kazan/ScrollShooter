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
    private int _layersCount;

    void Start()
    {
        _layersCount = _layers.Length;
    }

    void Update()
    {
        ApplyParallaxEffect();
    }

    /// <summary>
    /// Применяет параллакс-эффект к слоям.
    /// </summary>
    private void ApplyParallaxEffect()
    {
        for (int i = 0; i < _layersCount; i++)
        {
            _layers[i].position = transform.position * _coefficients[i];
        }
    }
}