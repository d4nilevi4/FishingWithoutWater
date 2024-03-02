using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.GameLogic.MeteorLogic
{
    public class MeteorManager : MonoBehaviour
    {
        private const string METEOR_PREFAB_PATH = "Meteors/Meteor";
        private const float SPAWN_TIME_EPSILON = 0.4f;
        private const float START_WAITING_TIME = 4f;
        

        [SerializeField] private float timeToSpawn;
        
        
        private Meteor _meteorPrefab;
        private float _timer;
        private bool _startedSpawn = false;

        private Meteor MeteorPrefab => _meteorPrefab ??= Resources.Load<Meteor>(METEOR_PREFAB_PATH);

        private void Start()
        {
            _timer = Time.time;
        }

        private void Update()
        {
            if(!_startedSpawn && _timer + START_WAITING_TIME > Time.time)
                return;

            if(_timer + GetCurrentSpawnTime() > Time.time)
                return;

            SpawnMeteor();
            _timer = Time.time;
        }

        private void SpawnMeteor()
        {
            
        }

        private float GetCurrentSpawnTime() =>
            timeToSpawn + Random.Range(-SPAWN_TIME_EPSILON, SPAWN_TIME_EPSILON);
    }
}