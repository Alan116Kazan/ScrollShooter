using UnityEngine;

/// <summary>
/// ����� ��� ���������� �������� � ����.
/// </summary>
public class StateMachine : MonoBehaviour
{
    [Header("��������� �����")]
    [Tooltip("�����, ������� ����� ����������� ��� �������.")]
    [SerializeField] private GameObject _firstScreen;

    private GameObject _currentScreen;

    private void Start()
    {
        if (_firstScreen == null)
        {
            Debug.LogError("��������� ����� �� ��������.", this);
            return;
        }

        ChangeState(_firstScreen);
    }

    /// <summary>
    /// ������ �������� ��������� �� ���������.
    /// </summary>
    /// <param name="nextScreen">�����, ������� ������ ��������.</param>
    public void ChangeState(GameObject nextScreen)
    {
        if (nextScreen == null)
        {
            Debug.LogWarning("������� ������� ��������� �� null.", this);
            return;
        }

        if (_currentScreen != null)
        {
            _currentScreen.SetActive(false);
        }

        nextScreen.SetActive(true);
        _currentScreen = nextScreen;
    }
}