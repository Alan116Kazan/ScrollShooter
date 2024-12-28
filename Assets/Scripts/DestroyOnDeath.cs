using UnityEngine;
using System.Collections;

/// <summary>
/// ����� ��� ���������� ������������ ������� ����� ������.
/// ������� ������ ����� ������������ �������� ����� ������.
/// </summary>
[RequireComponent(typeof(Death))]
public class DestroyOnDeath : MonoBehaviour
{
    private Death _death;

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
        // ������������ �� ������� ������ ��� ���������� �������
        _death.OnDeathEvent -= HandleDeath;
    }

    /// <summary>
    /// ���������� ������� ������: ���������� �������� �������.
    /// </summary>
    private void HandleDeath()
    {
        // ��������� �������� ��� �������� ������� ����� 2 ������� ����� ������
        StartCoroutine(DestroyAfterDelay(2f));
    }

    /// <summary>
    /// ���������� ������ ����� �������� ��������.
    /// </summary>
    /// <param name="delay">����� �������� � ��������.</param>
    private IEnumerator DestroyAfterDelay(float delay)
    {
        // ���� �������� ���������� ������� ����� ������������ �������
        yield return new WaitForSeconds(delay);

        // ������� ������
        Destroy(gameObject);
    }
}