using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private int healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health targetHealth = collision.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}