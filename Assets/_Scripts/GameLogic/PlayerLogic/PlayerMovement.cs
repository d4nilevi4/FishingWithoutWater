using _Scripts.GameLogic.Bounds;
using UnityEngine;

namespace _Scripts.GameLogic.PlayerLogic
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private PlayerBrain _brain;
        private PlayerInputActions _input;
    
        public void Construct(PlayerBrain brain, PlayerInputActions input)
        {
            _brain = brain;
            _input = input;
        }

        private void Update()
        {
            var moveDirection = _input.Player.Move.ReadValue<Vector2>();
        
            Move(moveDirection);
        }

        private void Move(Vector2 moveDirection)
        {
            var moveDirection3D = new Vector3(moveDirection.x, moveDirection.y, 0);
            var localPosition = transform.localPosition;

            localPosition += moveDirection3D * (moveSpeed * Time.deltaTime);

            CheckBounds(ref localPosition);

            ApplyLocalPosition(localPosition);
        }

        private void CheckBounds(ref Vector3 pos)
        {
            if (Mathf.Abs(pos.x) + _brain.PlayerRadius > MapBounds.Bounds.x)
            {
                pos.x = (MapBounds.Bounds.x - _brain.PlayerRadius) * Mathf.Sign(pos.x);
            }
            
            if (Mathf.Abs(pos.y) + _brain.PlayerRadius > MapBounds.Bounds.y)
            {
                pos.y = (MapBounds.Bounds.y - _brain.PlayerRadius) * Mathf.Sign(pos.y);
            }
        }

        private void ApplyLocalPosition(Vector3 position) =>
            transform.localPosition = position;
    }
}
