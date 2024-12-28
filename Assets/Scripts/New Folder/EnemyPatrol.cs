using UnityEngine;
using System.Collections;

/// <summary>
/// �����, ���������� �� �������������� ����� ����� ����� ���������.
/// </summary>
[RequireComponent(typeof(EnemyController))]
public class EnemyPatrol : MonoBehaviour
{
    [Header("������� ��������������")]
    [Tooltip("����� ������� ��������������.")]
    [SerializeField] private Transform _leftBoundary;

    [Tooltip("������ ������� ��������������.")]
    [SerializeField] private Transform _rightBoundary;

    [Header("��������� ��������������")]
    [Tooltip("�������� ������������.")]
    [SerializeField] private float _speed = 2f;

    [Tooltip("����� �������� ����� ����������.")]
    [SerializeField] private float _waitTime = 3f;

    private bool _movingRight = true;
    private bool _isWaiting = false;

    private EnemyController _enemyController;

    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        if (_isWaiting) return;

        Patrol();
    }

    /// <summary>
    /// ������ �������������� ����� ���������.
    /// </summary>
    private void Patrol()
    {
        // �������� Rigidbody2D ����� EnemyController
        Rigidbody2D rb = _enemyController.Rb;

        if (_movingRight)
        {
            // �������� ������
            rb.velocity = new Vector2(_speed, rb.velocity.y);

            // ������� ������, ���� ���������
            if (transform.localScale.x < 0)
                Flip();

            // �������� ���������� ������ �������
            if (transform.position.x >= _rightBoundary.position.x)
                StartCoroutine(WaitAndTurn(false));
        }
        else
        {
            // �������� �����
            rb.velocity = new Vector2(-_speed, rb.velocity.y);

            // ������� �����, ���� ���������
            if (transform.localScale.x > 0)
                Flip();

            // �������� ���������� ����� �������
            if (transform.position.x <= _leftBoundary.position.x)
                StartCoroutine(WaitAndTurn(true));
        }
    }

    /// <summary>
    /// ������� �����.
    /// </summary>
    public void Flip()
    {
        // ����������� ������� �� ��� X ��� ��������� �����������
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    /// <summary>
    /// �������� ����� ����������.
    /// </summary>
    /// <param name="turnRight">����������� ����� ��������: ������ ��� �����.</param>
    private IEnumerator WaitAndTurn(bool turnRight)
    {
        _isWaiting = true;

        // ������������� ��������
        _enemyController.Rb.velocity = Vector2.zero;

        // ���� ��������� �����
        yield return new WaitForSeconds(_waitTime);

        // �������� ����������� ��������
        _movingRight = turnRight;
        _isWaiting = false;
    }
}