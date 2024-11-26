using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private const float IdleState = 0;
    private const float RunState = 1;
    private const float RevertState = 2;
    private const float ChaseState = 3;

    [SerializeField] private float _speed, _timeToRevert, _chaseRadius, _attackRange;
    [SerializeField] private LayerMask _playerLayer;

    private Rigidbody2D _rb;
    private Transform _player;
    private SpriteRenderer _sp;

    private float _currentState;
    private float _currentTimeToRevert;
    private bool _isFacingRight;

    private bool _isAttacking;
    private bool _isBlocked;

    public bool IsAttacking => _isAttacking;
    public float CurrentVelocity { get; private set; }


    private void Awake()
    {
        _sp = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _currentState = RunState;
    }

    private void Update()
    {
        CurrentVelocity = _rb.velocity.magnitude;
        DetectPlayer();
        EnemyMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
        {
            _currentState = IdleState;
            _isBlocked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
        {
            _isBlocked = false;
        }
    }

    private void DetectPlayer()
    {
        if (_currentState != ChaseState)
        {
            Collider2D detectedPlayer = Physics2D.OverlapCircle(transform.position, _chaseRadius, _playerLayer);
            if (detectedPlayer != null)
            {
                _player = detectedPlayer.transform;
                _currentState = ChaseState;
            }
        }
        else if (_currentState == ChaseState && _player == null)
        {
            _currentState = RunState;
        }
    }

    private void EnemyMove()
    {
        _isAttacking = false;
        switch (_currentState)
        {
            case IdleState:
                HandleIdleState();
                break;

            case RunState:
                HandleRunState();
                break;

            case RevertState:
                HandleRevertState();
                break;

            case ChaseState:
                HandleChaseState();
                break;
        }

        Attack();
    }

    private void Attack()
    {
        if (_player != null && Vector2.Distance(transform.position, _player.position) <= _attackRange)
        {
            _rb.velocity = Vector2.zero;
            _isAttacking = true;
        }
    }

    private void HandleIdleState()
    {
        _currentTimeToRevert += Time.deltaTime;
        if (_currentTimeToRevert >= _timeToRevert)
        {
            _currentTimeToRevert = 0;
            _currentState = RevertState;
        }
    }

    private void HandleRunState()
    {
        _rb.velocity = Vector2.left * _speed;
        FlipSpriteBasedOnDirection(_speed < 0);
    }

    private void HandleRevertState()
    {
        FlipSpriteBasedOnDirection(!_isFacingRight);
        _speed *= -1;
        _currentState = RunState;
    }

    private void HandleChaseState()
    {
        if (_player != null && !_isBlocked)
        {
            float direction = Mathf.Sign(_player.position.x - transform.position.x);
            _rb.velocity = new Vector2(direction * Mathf.Abs(_speed), _rb.velocity.y);
            FlipSpriteBasedOnDirection(direction > 0);
        }
        else
        {
            _currentState = IdleState;
        }
    }

    private void FlipSpriteBasedOnDirection(bool shouldFlip)
    {
        if (_isFacingRight != shouldFlip)
        {
            _sp.flipX = !_sp.flipX;
            _isFacingRight = shouldFlip;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _chaseRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}