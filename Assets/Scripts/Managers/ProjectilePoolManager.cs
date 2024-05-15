using System.Collections.Generic;
using Abstracts;
using Enums;
using Misc;
using Pools;
using UnityEngine;

namespace Managers
{
    public class ProjectilePoolManager : Singleton<ProjectilePoolManager>
    {
        [SerializeField] private List<ProjectilePoolObject> _pools;

        private Dictionary<ProjectileType, Queue<BaseProjectile>> _poolDictionary;
        
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _poolDictionary = new Dictionary<ProjectileType, Queue<BaseProjectile>>();

            foreach (var pool in _pools)
            {
                Queue<BaseProjectile> objectPool = new Queue<BaseProjectile>();

                for (int i = 0; i < pool.Size; i++)
                {
                    BaseProjectile projectile = Instantiate(pool.ProjectilePF);
                    projectile.gameObject.SetActive(false);
                    objectPool.Enqueue(projectile);
                }

                _poolDictionary.Add(pool.ProjectileType, objectPool);
            }
        }

        public BaseProjectile SpawnFromPool(ProjectileType projectileType, BaseWeapon launchedWeapon, Vector3 position, Quaternion rotation)
        {
            if (!_poolDictionary.ContainsKey(projectileType) || _poolDictionary[projectileType].Count == 0)
                return null;

            var enemyToSpawn = _poolDictionary[projectileType].Dequeue();

            enemyToSpawn.Init(launchedWeapon);
            enemyToSpawn.gameObject.SetActive(true);
            enemyToSpawn.transform.position = position;
            enemyToSpawn.transform.rotation = rotation;

            return enemyToSpawn;
        }

        public void ReturnToPool(ProjectileType enemyType, BaseProjectile objectToReturn)
        {
            if (!_poolDictionary.ContainsKey(enemyType))
                return;

            objectToReturn.ResetObject();
            _poolDictionary[enemyType].Enqueue(objectToReturn);
        }
    }
}