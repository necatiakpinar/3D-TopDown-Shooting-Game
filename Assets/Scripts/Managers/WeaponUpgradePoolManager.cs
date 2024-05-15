using System.Collections.Generic;
using Abstracts;
using Enums;
using Misc;
using Pools;
using UnityEngine;

namespace Managers
{
    public class WeaponUpgradePoolManager : Singleton<WeaponUpgradePoolManager>
    {
        [SerializeField] private List<WeaponUpgradePoolObject> _pools;

        private Dictionary<WeaponAttachmentType, Queue<BaseWeaponUpgrade>> _poolDictionary;
        
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _poolDictionary = new Dictionary<WeaponAttachmentType, Queue<BaseWeaponUpgrade>>();

            foreach (var pool in _pools)
            {
                Queue<BaseWeaponUpgrade> objectPool = new Queue<BaseWeaponUpgrade>();

                for (int i = 0; i < pool.Size; i++)
                {
                    BaseWeaponUpgrade weaponUpgrade = Instantiate(pool.WeaponUpgradePF);
                    weaponUpgrade.gameObject.SetActive(false);
                    objectPool.Enqueue(weaponUpgrade);
                }

                _poolDictionary.Add(pool.UpgradeType, objectPool);
            }
        }

        public BaseWeaponUpgrade SpawnFromPool(WeaponAttachmentType weaponAttachmentType, Vector3 position, Quaternion rotation)
        {
            if (!_poolDictionary.ContainsKey(weaponAttachmentType) || _poolDictionary[weaponAttachmentType].Count == 0)
                return null;

            var weaponUpgradeToSpawn = _poolDictionary[weaponAttachmentType].Dequeue();

            weaponUpgradeToSpawn.Init();
            weaponUpgradeToSpawn.gameObject.SetActive(true);
            weaponUpgradeToSpawn.transform.position = position;
            weaponUpgradeToSpawn.transform.rotation = rotation;

            return weaponUpgradeToSpawn;
        }

        public void ReturnToPool(WeaponAttachmentType weaponAttachmentType, BaseWeaponUpgrade objectToReturn)
        {
            if (!_poolDictionary.ContainsKey(weaponAttachmentType))
                return;

            objectToReturn.ResetObject();
            _poolDictionary[weaponAttachmentType].Enqueue(objectToReturn);
        }
    }
}