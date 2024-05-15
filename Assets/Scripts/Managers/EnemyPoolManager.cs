using System.Collections.Generic;
using Abstracts;
using Enums;
using Misc;
using Pools;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class EnemyPoolManager : Singleton<EnemyPoolManager>
    {
        [SerializeField] private List<EnemyPoolObject> _pools;

        private Dictionary<EnemyType, Queue<BaseEnemy>> _poolDictionary;
        
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _poolDictionary = new Dictionary<EnemyType, Queue<BaseEnemy>>();

            foreach (var pool in _pools)
            {
                Queue<BaseEnemy> objectPool = new Queue<BaseEnemy>();

                for (int i = 0; i < pool.Size; i++)
                {
                    BaseEnemy enemy = Instantiate(pool.EnemyPf);
                    enemy.gameObject.SetActive(false);
                    objectPool.Enqueue(enemy);
                }

                _poolDictionary.Add(pool.EnemyType, objectPool);
            }
        }

        public BaseEnemy SpawnFromPool(EnemyType enemyType, Vector3 position, Quaternion rotation)
        {
            if (!_poolDictionary.ContainsKey(enemyType) || _poolDictionary[enemyType].Count == 0)
                return null;

            var enemyToSpawn = _poolDictionary[enemyType].Dequeue();

            enemyToSpawn.gameObject.SetActive(true);
            enemyToSpawn.transform.position = position;
            enemyToSpawn.transform.rotation = rotation;
            enemyToSpawn.Init();

            return enemyToSpawn;
        }

        public void ReturnToPool(EnemyType enemyType, BaseEnemy objectToReturn)
        {
            if (!_poolDictionary.ContainsKey(enemyType))
                return;

            objectToReturn.ResetObject();
            _poolDictionary[enemyType].Enqueue(objectToReturn);
        }
    }
}