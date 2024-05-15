using System.Collections.Generic;
using Abstracts;
using Enums;
using UnityEngine;
using UnityEngine.AI;

namespace Managers
{
    public class WeaponUpgradeManager : MonoBehaviour
    {
        [SerializeField] private List<BaseWeaponUpgrade> _weaponUpgrades;

        [SerializeField] private int _maxUpgradeCount = 5;
        private void Start()
        {
            for (int i = 0; i < _maxUpgradeCount; i++)
            {
                var spawnPosition = GetRandomPointOnNavMesh();
                var spawnedWeaponUpgrade = WeaponUpgradePoolManager.Instance.SpawnFromPool(WeaponAttachmentType.Barrel, spawnPosition, Quaternion.identity);
                _weaponUpgrades.Add(spawnedWeaponUpgrade);
            }
            
            for (int i = 0; i < _maxUpgradeCount; i++)
            {
                var spawnPosition = GetRandomPointOnNavMesh();
                var spawnedWeaponUpgrade = WeaponUpgradePoolManager.Instance.SpawnFromPool(WeaponAttachmentType.Scope, spawnPosition, Quaternion.identity);
                _weaponUpgrades.Add(spawnedWeaponUpgrade);
            }
            
            for (int i = 0; i < _maxUpgradeCount; i++)
            {
                var spawnPosition = GetRandomPointOnNavMesh();
                var spawnedWeaponUpgrade = WeaponUpgradePoolManager.Instance.SpawnFromPool(WeaponAttachmentType.ArmorPiercing, spawnPosition, Quaternion.identity);
                _weaponUpgrades.Add(spawnedWeaponUpgrade);
            }
        }
        
        private Vector3 GetRandomPointOnNavMesh()
        {
            NavMeshHit hit;
            Vector3 randomPoint = Vector3.zero;
            
            if (NavMesh.SamplePosition(Random.insideUnitSphere * 50f, out hit, 50f, NavMesh.AllAreas))
                randomPoint = hit.position;

            return randomPoint;
        }
    }
}