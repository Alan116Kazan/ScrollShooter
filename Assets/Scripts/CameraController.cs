using UnityEngine;
using Cinemachine;
using System.Collections;


public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void SmoothZoom(float targetSize)
    {
        StartCoroutine(ZoomCoroutine(targetSize));
    }

    // Корутин для плавного изменения размера
    private IEnumerator ZoomCoroutine(float targetSize)
    {
        if (_virtualCamera == null) yield break;

        float startSize = _virtualCamera.m_Lens.OrthographicSize; // Текущий размер
        float elapsedTime = 0f; // Время, прошедшее с начала изменения

        while (elapsedTime < 2f)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / 2f; // Нормализованное время
            _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startSize, targetSize, t); // Интерполяция
            yield return null;
        }

        // Устанавливаем точное значение в конце
        _virtualCamera.m_Lens.OrthographicSize = targetSize;
    }
}