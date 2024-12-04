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

    // ������� ��� �������� ��������� �������
    private IEnumerator ZoomCoroutine(float targetSize)
    {
        if (_virtualCamera == null) yield break;

        float startSize = _virtualCamera.m_Lens.OrthographicSize; // ������� ������
        float elapsedTime = 0f; // �����, ��������� � ������ ���������

        while (elapsedTime < 2f)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / 2f; // ��������������� �����
            _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startSize, targetSize, t); // ������������
            yield return null;
        }

        // ������������� ������ �������� � �����
        _virtualCamera.m_Lens.OrthographicSize = targetSize;
    }
}