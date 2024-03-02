using UnityEngine;

namespace _Scripts.GameLogic.Bounds
{
    public class MapBoundsDrawer : MonoBehaviour
    {
        [SerializeField] private Vector2 mapBounds;

        private void OnValidate()
        {
            MapBounds.SetBounds(mapBounds);
        }

        private void OnDrawGizmos()
        {
            DrawHelper.DrawWireCube(this, mapBounds);
        }
    }
}
