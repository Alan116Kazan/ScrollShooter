using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectDestroyer : MonoBehaviour
{
    [Header("Настройки")]
    [Tooltip("Объект, который нужно удалить.")]
    [SerializeField] private GameObject _targetObject;

    [Tooltip("Слой, который обозначает игрока.")]
    [SerializeField] private LayerMask _playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayerLayer(collision.gameObject.layer))
        {
            Destroy(_targetObject);
        }
    }
    private bool IsPlayerLayer(int layer)
    {
        return (_playerLayer.value & (1 << layer)) != 0;
    }
}