using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;

    [Header("Zoom Settings")]
    [SerializeField] private float _zoomDuration = 2f; // Длительность зума

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if (_virtualCamera == null)
        {
            Debug.LogError("Камера не найдена.");
        }
    }

    // Метод для начала плавного зума
    public void SmoothZoom(float targetSize)
    {
        // Запускаем корутину для плавного зума
        StartCoroutine(ZoomCoroutine(targetSize));
    }

    // Коррутина для плавного зума
    private IEnumerator ZoomCoroutine(float targetSize)
    {
        // Если виртуальная камера не существует, выходим из корутины
        if (_virtualCamera == null) yield break;

        // Получаем текущий размер камеры
        float startSize = _virtualCamera.m_Lens.OrthographicSize;
        float elapsedTime = 0f;

        // Плавно меняем размер камеры
        while (elapsedTime < _zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / _zoomDuration; // Нормализуем время
            _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startSize, targetSize, t); // Линейная интерполяция
            yield return null;
        }

        // Устанавливаем целевой размер в конце
        _virtualCamera.m_Lens.OrthographicSize = targetSize;
    }
}