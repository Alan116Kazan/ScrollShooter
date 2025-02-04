using UnityEngine;

public class SpriteColorChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Color _startColor = Color.white; // ��������� ����
    [SerializeField] private Color _targetColor = Color.red;  // ����, �� ������� ����� ������
    [SerializeField] private float _duration = 2f;            // ������������ ����� ����� �����

    private float _time;
    private bool _isReversing;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogError("�� ������� ����������� SpriteRenderer!");
            enabled = false;
        }
    }

    private void Update()
    {
        if (_spriteRenderer != null)
        {
            // ����������� ��� ��������� ����� � ����������� �� �����������
            _time += (_isReversing ? -1 : 1) * Time.deltaTime / _duration;

            // ������������ �������� time �� 0 �� 1
            if (_time >= 1f)
            {
                _time = 1f;
                _isReversing = true; // ������ �����������
            }
            else if (_time <= 0f)
            {
                _time = 0f;
                _isReversing = false; // ������ �����������
            }

            // ������ ����
            _spriteRenderer.color = Color.Lerp(_startColor, _targetColor, _time);
        }
    }
}
