using _Scripts.GameLogic;
using UnityEngine;

#if UNITY_EDITOR       
using UnityEditor;
#endif

namespace _Scripts
{
    public static class DrawHelper
    {
        public static void DrawRadius(MonoBehaviour unityObject, float radius)
        {
#if UNITY_EDITOR       
            var transform = unityObject.transform;
            
            Handles.DrawWireDisc(transform.position, -transform.forward, radius);
#endif
        }

        public static void DrawWireCube(MonoBehaviour unityObject, Vector2 mapBounds)
        {
#if UNITY_EDITOR      
            var transform = unityObject.transform;
            
            Handles.DrawWireCube(transform.position, new Vector3(mapBounds.x * 2, mapBounds.y * 2, 0));
#endif
        }
    }
}