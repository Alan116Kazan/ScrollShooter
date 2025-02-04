using UnityEngine;

/// <summary>
/// Класс, который управляет логикой переключателя сбрасывающего груз на трамплин
/// </summary>
public class SwitcherController : MonoBehaviour
{
    [SerializeField] private GameObject _anvil;

    private SwitcherAnimation _switcherAnimation;
    private Rigidbody2D _anvilRigidbody;

    private void Start()
    {
        _switcherAnimation = GetComponent<SwitcherAnimation>();
        _anvilRigidbody = _anvil.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            _switcherAnimation.ActivateSwitcher();

            _anvilRigidbody.bodyType = RigidbodyType2D.Dynamic;

            Destroy(collision.gameObject);
        }
    }
}
