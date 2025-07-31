using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Main.Scripts
{
    public class PlayerInputHandler: IInitializable, IDisposable
    {
        [Inject] private TestProgActions _actions;
        
        private Vector2 _movementInput;
        
        public Vector2 MovementInput => _movementInput;

        private Action _onJump;
        
        public void Initialize()
        {
            _actions.Player.Move.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
            _actions.Player.Move.canceled += _ => _movementInput = Vector2.zero;
            _actions.Player.Jump.performed += OnJump;
            _actions.Enable();
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            _onJump?.Invoke();
        }
        
        public void Subscribe(Action onJump)
        {
            _onJump = onJump;
        }

        private void Unsubscribe()
        {
            _onJump = null;
        }

        public void Dispose()
        {
            _actions.Disable();
            _actions?.Dispose();
            Unsubscribe();
        }
        
        public void Lock(bool state)
        {
            if (state)
            {
                _actions.Disable();    
            }
            else
            {
                _actions.Enable();
            }
        }
    }
}