using System;
using UnityEngine;

namespace _Scripts.GameLogic.MeteorLogic
{
    public class Meteor : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float radius;
        [SerializeField] private float speed;

        public event Action EventLand;

        private void OnDrawGizmos()
        {
            DrawHelper.DrawRadius(this, radius);
        }
    }
}