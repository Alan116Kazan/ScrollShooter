using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage = 10f; // ����, ������� ������� ������
    [SerializeField] private bool _destroyOnHit = true; // ����� �� ���������� ������ ����� ���������

    // �������, ������� ����������� ��� ������������ � ���-��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ��� ������, � ������� ��������� ������������, ����� ��� "Damageable"
        if (collision.CompareTag("Damageable"))
        {
            // �������� ��������� Health � �������
            Health targetHealth = collision.GetComponent<Health>();

            // ���� ��������� Health ������, ������� ����
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(_damage);
            }

            // ���� ��������� ����������� �������, �� ���������� ���
            if (_destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}