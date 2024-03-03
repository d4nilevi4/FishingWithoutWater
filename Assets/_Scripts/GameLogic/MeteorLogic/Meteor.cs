using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.GameLogic.MeteorLogic
{
    public class Meteor : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float meteorRadius;
        [SerializeField] private float speed;
        [SerializeField] private float startWaitTime;

        private Vector3 _landPosition;
        private Sequence _meteorSequence;
        
        public event Action<Meteor> EventLand;

        public float MeteorRadius => meteorRadius;

        public void Construct(Vector3 landPosition)
        {
            _landPosition = landPosition;
        }

        private void Start()
        {
            _meteorSequence?.Kill();

            _meteorSequence = DOTween.Sequence();

            var flyTime = Mathf.Abs((_landPosition - transform.localPosition).magnitude) / speed;


            _meteorSequence
                .AppendInterval(startWaitTime)
                .Append(transform.DOLocalMove(_landPosition, flyTime).SetEase(Ease.Linear))
                .OnComplete(() => EventLand?.Invoke(this))
                .OnKill(() => Destroy(gameObject));
        }

        private void OnDrawGizmos()
        {
            DrawHelper.DrawRadius(this, meteorRadius);
        }
    }
}