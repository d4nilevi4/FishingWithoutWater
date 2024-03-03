using System;
using UnityEngine;

namespace _Scripts.GameLogic.PlayerLogic
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int SpeedX = Animator.StringToHash("SpeedX");
        private static readonly int SpeedY = Animator.StringToHash("SpeedY");
        private static readonly int SpeedMagnitude = Animator.StringToHash("SpeedMagnitude");

        private PlayerInputActions _input;
        private Animator _animator;

        private Animator Animator => _animator ??= GetComponent<Animator>();

        public void Construct(PlayerInputActions input)
        {
            _input = input;
        }

        private void Update()
        {
            var moveDirection =  _input.Player.Move.ReadValue<Vector2>();
            
            Debug.Log(moveDirection);
            
            Animator.SetFloat(SpeedX, moveDirection.x);
            Animator.SetFloat(SpeedY, moveDirection.y);
            Animator.SetFloat(SpeedMagnitude, moveDirection.magnitude);
        }
    }
}