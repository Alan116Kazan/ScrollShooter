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

    private Vector3[] _initialPositions;
    private int _layersCount;

    void Start()
    {
        _layersCount = _layers.Length;
        _initialPositions = new Vector3[_layersCount];

        // ��������� ��������� ������� ������� ����
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
    /// ��������� ���������-������ � �����.
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