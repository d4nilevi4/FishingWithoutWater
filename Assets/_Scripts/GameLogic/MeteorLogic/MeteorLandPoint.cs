using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.GameLogic.MeteorLogic
{
    public class MeteorLandPoint : MonoBehaviour
    {
        private const float RESIZE_VALUE = 1.1f;
        private const float DURATION_RESIZE_VALUE = .2f;
        
        
        [SerializeField] private SpriteRenderer sprite;

        private Meteor _meteor;

        private Sequence _sizeSequence;
        

        public void Construct(Meteor meteor)
        {
            _meteor = meteor;
            _meteor.EventLand += OnMeteorLand;
        }

        private void Start()
        {
            _sizeSequence?.Kill();

            _sizeSequence = DOTween.Sequence();

            _sizeSequence
                .Append(transform
                    .DOScale(Vector3.one * RESIZE_VALUE, DURATION_RESIZE_VALUE)
                    .SetLoops(Int32.MaxValue, LoopType.Yoyo));
        }

        private void OnMeteorLand(Meteor _)
        {
            _meteor.EventLand -= OnMeteorLand;
            _sizeSequence.Kill();
            Destroy(gameObject);
        }
    }
}