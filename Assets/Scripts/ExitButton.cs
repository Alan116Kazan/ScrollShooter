using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();

        // Чтобы выход работал в редакторе Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}