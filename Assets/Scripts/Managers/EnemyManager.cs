
using System;
using System.Collections.Generic;
using Abstracts;
using Enums;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Managers
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private List<BaseEnemy> _enemies;
        [SerializeField] private int _maxEnemyCount = 7;
        [SerializeField] private int _minEnemyCount = 3;
        private void OnEnable()
        {
            Action<object[]> onEnemyDead = (parameters) => OnEnemyDead((BaseEnemy)parameters[0]);
            EventManager.Subscribe(ActionType.OnEnemyDead, onEnemyDead);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe(ActionType.OnEnemyDead);
        }
        
        private void OnEnemyDead(BaseEnemy enemy)
        {
            _enemies.Remove(enemy);

            if (_enemies.Count < _minEnemyCount)
            {
                for (int i = 0; i < _minEnemyCount; i++)
                {
                    var spawnPosition = GetRandomPointOnNavMesh();
                    var spawnedEnemy = EnemyPoolManager.Instance.SpawnFromPool(EnemyType.BasicEnemy, spawnPosition, Quaternion.identity);
                    _enemies.Add(spawnedEnemy);    
                }
            }
        }
        
        private void Start()
        {
            for (int i = 0; i < _maxEnemyCount; i++)
            {
                var spawnPosition = GetRandomPointOnNavMesh();
                var spawnedEnemy = EnemyPoolManager.Instance.SpawnFromPool(EnemyType.BasicEnemy, spawnPosition, Quaternion.identity);
                _enemies.Add(spawnedEnemy);
            }
        }
        
        Vector3 GetRandomPointOnNavMesh()
        {
            NavMeshHit hit;
            Vector3 randomPoint = Vector3.zero;
            
            if (NavMesh.SamplePosition(Random.insideUnitSphere * 30f, out hit, 30f, NavMesh.AllAreas))
                randomPoint = hit.position;

            return randomPoint;
        }
    }
}