using System.Collections.Generic;
using _Scripts.GameLogic.Bounds;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.GameLogic.MeteorLogic
{
    public class MeteorManager : MonoBehaviour
    {
        private const string METEOR_PREFAB_PATH = "Meteors/Meteor";
        private const string METEOR_LAND_POINT_PREFAB_PATH = "Meteors/MeteorLandPoint";
        private const float SPAWN_TIME_EPSILON = 0.4f;
        private const float START_WAITING_TIME = 4f;

        [SerializeField] private float timeToSpawn;

        private Meteor _meteorPrefab;
        private MeteorLandPoint _meteorLandPointPrefab;
        private float _timer;
        private bool _startedSpawn = false;
        private Vector2 _spawnOffset;
        private Dictionary<Meteor, MeteorLandPoint> _completeMeteor;
        

        private Meteor MeteorPrefab => _meteorPrefab ??= Resources.Load<Meteor>(METEOR_PREFAB_PATH);
        private MeteorLandPoint MeteorLandPointPrefab => _meteorLandPointPrefab ??= Resources.Load<MeteorLandPoint>(METEOR_LAND_POINT_PREFAB_PATH);
        private float SpawnIndent => MeteorPrefab.MeteorRadius;

        private Vector2 SpawnOffset => _spawnOffset == Vector2.zero
            ? new Vector2(MapBounds.Bounds.x - MeteorPrefab.MeteorRadius - SpawnIndent,
                MapBounds.Bounds.y - MeteorPrefab.MeteorRadius - SpawnIndent)
            : _spawnOffset;

        private void Start()
        {
            _timer = Time.time;
        }

        private void Update()
        {
            if (!_startedSpawn && _timer + START_WAITING_TIME > Time.time)
                return;

            if (_timer + GetCurrentSpawnTime() > Time.time)
                return;

            SpawnCompleteMeteor();
            _timer = Time.time;
        }

        private void SpawnCompleteMeteor()
        {
            var meteorLandPosition = GetMeteorLandPosition();
            
            var meteor = SpawnMeteor(meteorLandPosition);
        }

        private Meteor SpawnMeteor(Vector3 meteorLandPosition)
        {
            var meteorSpawnPosition = GetMeteorSpawnPosition(meteorLandPosition);

            var meteor = Instantiate(MeteorPrefab, transform);
            meteor.transform.localPosition = meteorSpawnPosition;
            meteor.Construct(meteorLandPosition);

            return meteor;
        }

        private Vector3 GetMeteorLandPosition()
        {
            var landPosX = Random.Range(-SpawnOffset.x, SpawnOffset.x);
            var landPosY = Random.Range(-SpawnOffset.y, SpawnOffset.y);

            var meteorLandPosition = new Vector3(landPosX, landPosY, 0);
            return meteorLandPosition;
        }

        private Vector3 GetMeteorSpawnPosition(Vector3 meteorLandPosition)
        {
            var sizeCoefficient = MapBounds.Bounds.x /
                                  Mathf.Max(Mathf.Abs(meteorLandPosition.x), Mathf.Abs(meteorLandPosition.y));

            var meteorOffsetPosition = meteorLandPosition * sizeCoefficient;
            var meteorSpawnPosition =
                meteorOffsetPosition + meteorOffsetPosition.normalized * (MeteorPrefab.MeteorRadius * 2);
            return meteorSpawnPosition;
        }

        private float GetCurrentSpawnTime() =>
            timeToSpawn + Random.Range(-SPAWN_TIME_EPSILON, SPAWN_TIME_EPSILON);
    }
}