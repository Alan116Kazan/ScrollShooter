using UnityEngine;

/// <summary>
/// �����, ������� ��������� ��������� ������� � ��������
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
