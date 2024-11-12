using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            Health targetHealth = collision.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(_damage);
            }

            Destroy(gameObject);
        }
    }
}