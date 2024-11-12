using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Arrow Settings")]
    [SerializeField] private GameObject _arrowPrefab;
    [SerializeField] private Transform _shootPoint;
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

    public void Shoot()
    {
        GameObject arrow = CreateArrow();
        SetArrowVelocity(arrow);
        AdjustArrowOrientation(arrow);
    }

    private void UpdateShootPointPosition()
    {
        float xOffset = Mathf.Abs(_shootPoint.localPosition.x);
        _shootPoint.localPosition = new Vector3(_spriteRenderer.flipX ? -xOffset : xOffset, _shootPoint.localPosition.y, _shootPoint.localPosition.z);
    }

    private GameObject CreateArrow()
    {
        return Instantiate(_arrowPrefab, _shootPoint.position, Quaternion.identity);
    }

    private void SetArrowVelocity(GameObject arrow)
    {
        Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
        float direction = _spriteRenderer.flipX ? -1f : 1f;
        arrowRb.velocity = new Vector2(_arrowSpeed * direction, 0f);
    }

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