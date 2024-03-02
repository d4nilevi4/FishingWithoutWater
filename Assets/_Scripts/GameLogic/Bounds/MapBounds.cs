using UnityEngine;

namespace _Scripts.GameLogic.Bounds
{
    public static class MapBounds
    {
        public static Vector2 Bounds;

        public static Vector2 GetBounds() => Bounds;

        public static void SetBounds(Vector2 bounds) => Bounds = bounds;
    }
}