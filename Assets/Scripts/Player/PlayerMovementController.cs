using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Serialized in Inspector
        
        [SerializeField] private float jumpVelocity;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float fallMultiplier = 2.5f; //added gravity when character falling after a normal jump
        [SerializeField] private float lowJumpMultiplier = 2f; //added gravity when character falling after a low jump
        [SerializeField] private AudioClip jumpSound;

        #endregion
        
        #region Public Methods - Input System
        
        /// <summary>
        /// Called from Input System event when movement input from player
        /// </summary>
        /// <param name="context"></param> Information about the event
        public void Move(InputAction.CallbackContext context)
        {
            _inputX = context.ReadValue<Vector2>().x;
        }
        
        /// <summary>
        /// Called from Input System event when jump input from player
        /// </summary>
        /// <param name="context"></param> Information about the event
        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed && _isGrounded)
            {
                _rigidbody.velocity = Vector2.up * jumpVelocity;
                PlayJumpSoundFx();
            }
        }

        #endregion

        #region Init

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _coll = GetComponent<Collider2D>();
            _groundMask = LayerMask.GetMask("Ground");
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        #endregion

        #region Update

        private void Update()
        {
            _isGrounded = CheckIsGrounded();
            _rigidbody.velocity = new Vector2(_inputX * moveSpeed, _rigidbody.velocity.y);
            UpdateAnimationState();
            UpdateJumpGravity();
        }
        
        #endregion

        #region Private Methods
        
        private void UpdateJumpGravity()
        {
            if (_rigidbody.velocity.y < -0.1f)
            {
                _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (_rigidbody.velocity.y > 0.1f && !Gamepad.current.buttonSouth.isPressed)
            {
                _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        
        private void PlayJumpSoundFx()
        {
            _audioSource.PlayOneShot(jumpSound);
        }

        private void UpdateAnimationState()
        {
            MovementState state;

            Vector2 rigidbodyVelocity = _rigidbody.velocity;
            
            if (rigidbodyVelocity.x > 0.1f)
            {
                state = MovementState.Running;
                
                //Flip player transform to face right
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (rigidbodyVelocity.x < -0.1f)
            {
                state = MovementState.Running;
                
                //Flip player transform to face left
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                state = MovementState.Idle;
            }
        
            if (rigidbodyVelocity.y > 0.1f)
            {
                state = MovementState.Jumping;
            }
            else if (rigidbodyVelocity.y < -0.1f)
            {
                state = MovementState.Falling;
            }

            if (_currentState != state)
            {
                _currentState = state;
                _animator.SetInteger(StateParameter, (int)state);
            }
        }

        private bool CheckIsGrounded()
        {
            var bounds = _coll.bounds;
            
            //@Todo : Use non alloc version for performance
            _hit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0.1f, _groundMask);
            return _hit.collider != null;
        }

        #endregion
        
        #region Private - Enums

        private enum MovementState
        {
            Idle,
            Running,
            Jumping,
            Falling
        }

        #endregion

        #region Private Variables
        
        private static readonly int StateParameter = Animator.StringToHash("State");
        private int _groundMask;
        private float _inputX;
        private bool _isGrounded;
        private Animator _animator;
        private AudioSource _audioSource;
        private Collider2D _coll;
        private MovementState _currentState = MovementState.Idle;
        private RaycastHit2D _hit;
        private Rigidbody2D _rigidbody;

        #endregion
    }
}
