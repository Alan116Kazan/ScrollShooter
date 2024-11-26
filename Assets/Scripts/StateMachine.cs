using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject _firstScreen;

    private GameObject _currentScreen;

    private void Start()
    {
        ChangeState(_firstScreen);
    }
    public void ChangeState(GameObject nextScreen)
    {
        if (_currentScreen != null)
        {
            _currentScreen.SetActive(false);
        }
        nextScreen.SetActive(true);
        _currentScreen = nextScreen;
    }
}
