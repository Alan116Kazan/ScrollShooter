using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Открыть сцену по имени.
    /// </summary>
    /// <param name="sceneName">Имя сцены для загрузки.</param>
    public void OpenScene(string sceneName)
    {
        Time.timeScale = 1f;
        // Проверка, существует ли сцена с таким именем
        if (SceneExists(sceneName))
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        else
        {
            Debug.LogError($"Сцена с именем {sceneName} не найдена!");
        }
    }

    /// <summary>
    /// Перезапустить текущую сцену.
    /// </summary>
    public void RestartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        OpenScene(currentSceneName);
    }

    /// <summary>
    /// Проверка существования сцены по имени.
    /// </summary>
    /// <param name="sceneName">Имя сцены для проверки.</param>
    /// <returns>Возвращает true, если сцена существует, иначе false.</returns>
    private bool SceneExists(string sceneName)
    {
        // Проверка, что сцена существует в билде
        int sceneIndex = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/" + sceneName + ".unity");
        return sceneIndex != -1;
    }

    /// <summary>
    /// Асинхронная загрузка сцены.
    /// </summary>
    /// <param name="sceneName">Имя сцены для загрузки.</param>
    /// <returns>Возвращает корутину для асинхронной загрузки.</returns>
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // Ожидаем завершения загрузки сцены
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}