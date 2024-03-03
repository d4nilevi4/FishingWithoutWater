using System;
using UnityEngine;

namespace _Scripts.GameLogic.MeteorLogic
{
    public class MeteorLandPoint : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;

        private Meteor _meteor;

        public void Construct(Meteor meteor)
        {
            _meteor = meteor;
            _meteor.EventLand += OnMeteorLand;
        }
        
        private void OnMeteorLand()
        {
            _meteor.EventLand -= OnMeteorLand;
            Destroy(gameObject);
        }
    }
}