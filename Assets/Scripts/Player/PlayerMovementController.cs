using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    public enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling
    }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _groundMask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        _isGrounded = CheckIsGrounded();
        _rigidbody.velocity = new Vector2(_inputX * moveSpeed, _rigidbody.velocity.y);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (_rigidbody.velocity.x > 0.1f)
        {
            state = MovementState.Running;
            //_spriteRenderer.flipX = false;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_rigidbody.velocity.x < -0.1f)
        {
            state = MovementState.Running;
            //_spriteRenderer.flipX = true;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            state = MovementState.Idle;
        }
        
        if (_rigidbody.velocity.y > 0.1f)
        {
            state = MovementState.Jumping;
        }
        else if (_rigidbody.velocity.y < -0.1f)
        {
            state = MovementState.Falling;
        }

        if (_currentState != state)
        {
            _currentState = state;
            _animator.SetInteger(_stateParameter, (int) state);
        }
    }

    private bool CheckIsGrounded()
    {
        //@Todo : Use non alloc version for performance
        _hit = Physics2D.BoxCast(_coll.bounds.center, _coll.bounds.size, 0f, Vector2.down, 0.1f, _groundMask);
        return _hit.collider != null;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _inputX = context.ReadValue<Vector2>().x;
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private float _inputX;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private int _groundMask;
    private RaycastHit2D _hit;
    private Collider2D _coll;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private MovementState _currentState = MovementState.Idle;

    private static readonly int _stateParameter = Animator.StringToHash("State");
}
