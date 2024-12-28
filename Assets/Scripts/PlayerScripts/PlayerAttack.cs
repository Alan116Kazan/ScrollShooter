using UnityEngine;

/// <summary>
/// Управляет атакой игрока.
/// </summary>
[RequireComponent(typeof(Bow), typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    [Header("Настройки")]
    [Tooltip("Время удержания кнопки атаки для заряда выстрела.")]
    [SerializeField] private float _chargeTime = 0.3f;

    private Bow _bow;
    private PlayerMovement _playerMovement;

    private bool _isFiring;
    private float _fireButtonPressedTime;

    /// <summary>
    /// Указывает, находится ли игрок в состоянии атаки.
    /// </summary>
    public bool IsFiring => _isFiring;

    private void Awake()
    {
        _bow = GetComponent<Bow>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    /// <summary>
    /// Начинает процесс атаки.
    /// </summary>
    public void StartAttack()
    {
        if (!_playerMovement.IsGrounded) return;

        _isFiring = true;
        _fireButtonPressedTime = Time.time;
    }

    /// <summary>
    /// Завершает процесс атаки и выполняет выстрел, если кнопка удерживалась достаточно долго.
    /// </summary>
    public void EndAttack()
    {
        if (!_isFiring) return;

        _isFiring = false;

        if (Time.time - _fireButtonPressedTime >= _chargeTime)
        {
            _bow.Shoot();
        }
    }
}