using UnityEngine;

public class ParallaxConroller : MonoBehaviour
{
    [SerializeField] private Transform[] _layers;
    [SerializeField] private float[] _coeff;

    private int _layersCount;

    void Start()
    {
        _layersCount = _layers.Length;
    }

    void Update()
    {
        for (int i = 0; i < _layersCount; i++)
        {
            _layers[i].position = transform.position * _coeff[i];
        }
    }
}