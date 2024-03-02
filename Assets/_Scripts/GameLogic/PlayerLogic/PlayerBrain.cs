using UnityEngine;

namespace _Scripts.GameLogic.PlayerLogic
{
    public class PlayerBrain : MonoBehaviour
    {
        [SerializeField] private PlayerMovement movement;

        [SerializeField] private float playerRadius;

        private PlayerInputActions _input;

        public float PlayerRadius => playerRadius;

        private void Awake()
        {
            _input = new PlayerInputActions();
            
            movement.Construct(this, _input);
        }

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
        
        
        private void OnDrawGizmos()
        {
            DrawHelper.DrawRadius(this, playerRadius);
        }

    }
}