using UnityEngine;

namespace _Scripts.GameLogic.PlayerLogic
{
    public class PlayerBrain : MonoBehaviour
    {
        [SerializeField] private PlayerMovement movement;
        [SerializeField] private PlayerAnimator animator;

        [SerializeField] private float playerRadius;

        private PlayerInputActions _input;

        public float PlayerRadius => playerRadius;

        private void Awake()
        {
            _input = new PlayerInputActions();
            
            movement.Construct(this, _input);
            animator.Construct(_input);
        }

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
        
        
        private void OnDrawGizmos()
        {
            DrawHelper.DrawRadius(this, playerRadius);
        }

    }
}