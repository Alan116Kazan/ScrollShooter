using UnityEngine;

/// <summary>
/// Класс, который управляет анимацией переключателя
/// </summary>
public class SwitcherAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivateSwitcher()
    {
        animator.SetBool("isActivated", true);
    }
}
