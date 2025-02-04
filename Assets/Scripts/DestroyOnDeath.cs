using UnityEngine;
using System.Collections;

/// <summary>
/// ������� ������ ����� ������ � ��������� � ��������� ����.
/// </summary>
[RequireComponent(typeof(Death))]
public class DestroyOnDeath : MonoBehaviour
{
    private Death _death;

    private int _points = 10; // ���� �� ����������� �������

    private void Awake()
    {
        _death = GetComponent<Death>();
    }

    private void OnEnable()
    {
        // ������������� �� ������� ������
        _death.OnDeathEvent += HandleDeath;
    }

    private void OnDisable()
    {
        // ������������ �� ������� ������
        _death.OnDeathEvent -= HandleDeath;
    }

    /// <summary>
    /// ���������� ��� ������ �������, ��������� ���� � ������� ������.
    /// </summary>
    private void HandleDeath()
    {
        ScoreManager.Instance.IncreaseScore(_points);
        StartCoroutine(DestroyAfterDelay(1f));
    }

    /// <summary>
    /// ������� ������ ����� �������� �����.
    /// </summary>
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}