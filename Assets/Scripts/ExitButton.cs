using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();

        // ����� ����� ������� � ��������� Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}