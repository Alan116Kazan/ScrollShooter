using UnityEngine;

/// <summary>
/// �����, ����������� ��������� �� ����.
/// </summary>
public class Bow : MonoBehaviour
{
    [Header("��������� ������")]
    [Tooltip("������ ������, ������� ����� ������ ��� ��������.")]
    [SerializeField] private GameObject _arrowPrefab;

    [Tooltip("�����, �� ������� ������������ �������.")]
    [SerializeField] private Transform _shootPoint;

    [Tooltip("�������� ������ ������.")]
    [SerializeField] private float _arrowSpeed = 10f;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateShootPointPosition();
    }

    /// <summary>
    /// ���������� ������� �������.
    /// </summary>
    public void Shoot()
    {
        if (_arrowPrefab == null || _shootPoint == null)
        {
            Debug.LogWarning("�� ��������� ������ ������ ��� ����� ��������.", this);
            return;
        }

        GameObject arrow = CreateArrow();
        SetArrowVelocity(arrow);
        AdjustArrowOrientation(arrow);
    }

    /// <summary>
    /// ��������� ������� ����� �������� � ����������� �� ����������� ���������.
    /// </summary>
    private void UpdateShootPointPosition()
    {
        if (_shootPoint == null) return;

        float xOffset = Mathf.Abs(_shootPoint.localPosition.x);
        _shootPoint.localPosition = new Vector3(
            _spriteRenderer.flipX ? -xOffset : xOffset,
            _shootPoint.localPosition.y,
            _shootPoint.localPosition.z
        );
    }

    /// <summary>
    /// ������� ������ �� ������� ����� ��������.
    /// </summary>
    /// <returns>��������� ������ ������.</returns>
    private GameObject CreateArrow()
    {
        return Instantiate(_arrowPrefab, _shootPoint.position, Quaternion.identity);
    }

    /// <summary>
    /// ������������� �������� � ����������� ������ ������.
    /// </summary>
    /// <param name="arrow">������ ������.</param>
    private void SetArrowVelocity(GameObject arrow)
    {
        Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
        if (arrowRb == null)
        {
            Debug.LogWarning("������ �� �������� Rigidbody2D.", arrow);
            return;
        }

        float direction = _spriteRenderer.flipX ? -1f : 1f;
        arrowRb.velocity = new Vector2(_arrowSpeed * direction, 0f);
    }

    /// <summary>
    /// ����������� ���������� ������ � ����������� �� ����������� ��������.
    /// </summary>
    /// <param name="arrow">������ ������.</param>
    private void AdjustArrowOrientation(GameObject arrow)
    {
        if (_spriteRenderer.flipX)
        {
            Vector3 arrowScale = arrow.transform.localScale;
            arrowScale.x = -Mathf.Abs(arrowScale.x);
            arrow.transform.localScale = arrowScale;
        }
    }
}