using System;
using UnityEngine;

namespace _Scripts.GameLogic.MeteorLogic
{
    public class Meteor : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float meteorRadius;
        [SerializeField] private float speed;

        private Vector3 _landPosition;
        
        public event Action EventLand;

        public float MeteorRadius => meteorRadius;

        public void Construct(Vector3 landPosition)
        {
            _landPosition = landPosition;
            Destroy(gameObject, 2f);
        }

        private void OnDrawGizmos()
        {
            DrawHelper.DrawRadius(this, meteorRadius);
        }
    }
}