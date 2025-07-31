using Main.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class PlayerMovement : MonoBehaviour, IInitializable
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private static readonly int FreeFall = Animator.StringToHash("FreeFall");
    
    
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _playerModel;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speedModifier = 1f;
    [SerializeField] private float _jumpForce = 5f;
    
    [SerializeField] private float _raycastOffset = 0.1f;
    private readonly float _groundCheckDistance = 0.1f;

    private float _fallTimeout = 0.15f;
	private float _fallTimeoutDelta;
    private bool _isGrounded;
    
    [Inject] private PlayerInputHandler _playerInputHandler;

    public void Initialize()
    {
        _playerInputHandler.Subscribe(OnJump);
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        Move();
        
    }

    private void Move()
    {
        var input = _playerInputHandler.MovementInput;
        
        var velocity = _rigidbody.linearVelocity;
        velocity.x = input.x * _speedModifier;
        _rigidbody.linearVelocity = velocity;

        Animate(input);
        
    }

    private void Animate(Vector2 input)
    {
        _animator.SetFloat(Speed, Mathf.Abs(_rigidbody.linearVelocity.x));
        
        if (_isGrounded)
        {
            _fallTimeoutDelta = _fallTimeout;               

            _animator.SetBool(Jump, false);
            _animator.SetBool(FreeFall, false);
            _animator.SetBool(Grounded, true);
        }
        else {
            if (_fallTimeoutDelta >= 0.0f)
            {
                _fallTimeoutDelta -= Time.deltaTime;
            }
            else
            {
                _animator.SetBool(Grounded, false);
                _animator.SetBool(FreeFall, true);
            }
        }
       
        
        if (input == Vector2.zero) return;
        var direction = new Vector3(input.x, 0f, 0f).normalized;
        _playerModel.rotation = Quaternion.LookRotation(direction);
    }

    private void CheckGrounded()
    {
        _isGrounded = Physics.Raycast(_rigidbody.position + Vector3.up * _raycastOffset, Vector3.down, _groundCheckDistance + 0.1f);
    }
  
    private void OnJump()
    {
        if(!_isGrounded) return;
        _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, 0f, _rigidbody.linearVelocity.z);
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
 		_animator.SetBool(Jump, true);
    }
}
