using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private bool _destroyOnHit = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            Health targetHealth = collision.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(_damage);
            }

            if (_destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}