using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;

    [Header("Zoom Settings")]
    [SerializeField] private float _zoomDuration = 2f; // ������������ ����

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if (_virtualCamera == null)
        {
            Debug.LogError("������ �� �������.");
        }
    }

    // ����� ��� ������ �������� ����
    public void SmoothZoom(float targetSize)
    {
        // ��������� �������� ��� �������� ����
        StartCoroutine(ZoomCoroutine(targetSize));
    }

    // ��������� ��� �������� ����
    private IEnumerator ZoomCoroutine(float targetSize)
    {
        // ���� ����������� ������ �� ����������, ������� �� ��������
        if (_virtualCamera == null) yield break;

        // �������� ������� ������ ������
        float startSize = _virtualCamera.m_Lens.OrthographicSize;
        float elapsedTime = 0f;

        // ������ ������ ������ ������
        while (elapsedTime < _zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / _zoomDuration; // ����������� �����
            _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startSize, targetSize, t); // �������� ������������
            yield return null;
        }

        // ������������� ������� ������ � �����
        _virtualCamera.m_Lens.OrthographicSize = targetSize;
    }
}