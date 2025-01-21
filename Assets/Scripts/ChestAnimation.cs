using UnityEngine;

/// <summary>
/// Класс, который управляет анимацией сундука с аптечкой
/// </summary>
public class ChestAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChestOpen()
    {
        _animator.SetBool("IsOpened", true);
    }
}
