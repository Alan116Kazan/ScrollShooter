using UnityEngine;

/// <summary>
/// ������ ��� ������������ �������, ���� �� ������� �� ������� �������� �������.
/// </summary>
public class TeleportScript : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _teleportPoint;

    private void Update()
    {
        if (transform.position.x < _teleportPoint.position.x)
        {
            transform.position = new Vector3(_spawnPoint.position.x, transform.position.y, transform.position.z);
        }
    }
}
