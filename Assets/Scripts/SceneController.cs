using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// ������� ����� �� �����.
    /// </summary>
    /// <param name="sceneName">��� ����� ��� ��������.</param>
    public void OpenScene(string sceneName)
    {
        Time.timeScale = 1f;
        // ��������, ���������� �� ����� � ����� ������
        if (SceneExists(sceneName))
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        else
        {
            Debug.LogError($"����� � ������ {sceneName} �� �������!");
        }
    }

    /// <summary>
    /// ������������� ������� �����.
    /// </summary>
    public void RestartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        OpenScene(currentSceneName);
    }

    /// <summary>
    /// �������� ������������� ����� �� �����.
    /// </summary>
    /// <param name="sceneName">��� ����� ��� ��������.</param>
    /// <returns>���������� true, ���� ����� ����������, ����� false.</returns>
    private bool SceneExists(string sceneName)
    {
        // ��������, ��� ����� ���������� � �����
        int sceneIndex = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/" + sceneName + ".unity");
        return sceneIndex != -1;
    }

    /// <summary>
    /// ����������� �������� �����.
    /// </summary>
    /// <param name="sceneName">��� ����� ��� ��������.</param>
    /// <returns>���������� �������� ��� ����������� ��������.</returns>
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // ������� ���������� �������� �����
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}