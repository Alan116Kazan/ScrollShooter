using UnityEngine;

/// <summary>
/// ��������� ���������-�������� ��� ����.
/// </summary>
public class ParallaxController : MonoBehaviour
{
    [Header("��������� �����")]
    [Tooltip("����, ������� ��������� � ����������.")]
    [SerializeField] private Transform[] _layers;

    [Tooltip("������������ ���������� ��� ������� ����.")]
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
    /// ��������� ���������-������ � �����.
    /// </summary>
    private void ApplyParallaxEffect()
    {
        for (int i = 0; i < _layersCount; i++)
        {
            _layers[i].position = transform.position * _coefficients[i];
        }
    }
}