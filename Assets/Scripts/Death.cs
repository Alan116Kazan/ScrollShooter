using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Death : MonoBehaviour
{
    [Header("Death Settings")]
    [SerializeField] private GameObject _gameoverPanel;
    [SerializeField] private MonoBehaviour _movementScript;

    private Health _health;
    private bool _isDead = false;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDeath += HandleDeath;
    }

    private void HandleDeath()
    {
        if (_isDead) return;

        _isDead = true;

        if (_movementScript != null)
        {
            _movementScript.enabled = false;
        }

        if (_gameoverPanel != null)
        {
            _gameoverPanel.SetActive(true);
        }

        StartCoroutine(DestroyAfterDelay(2f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _health.OnDeath -= HandleDeath;
    }
}