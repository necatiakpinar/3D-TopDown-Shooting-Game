using System;
using System.Collections;
using System.Collections.Generic;
using Abstracts;
using Data;
using Enums;
using Managers;
using ScriptableObjects.Data.Weapons;
using UnityEngine;

namespace Weapons
{
    public class RocketLauncher : BaseWeapon
    {
        protected override void SetupAttachments()
        {
            var armorPiercingAttachment = new WeaponAttachment(WeaponAttachmentType.ArmorPiercing);
            var barrelAttachment = new WeaponAttachment(WeaponAttachmentType.Barrel);
            
            _weaponAttachments = new List<WeaponAttachment>();
            _weaponAttachments.Add(armorPiercingAttachment);
            _weaponAttachments.Add(barrelAttachment);
        }

        public override IEnumerator TryShoot(bool isPlayerLaunched)
        {
            _canShoot = false;
            var bullet = ProjectilePoolManager.Instance.SpawnFromPool(_projectileType, this, _projectileSpawnPoint.transform.position, Quaternion.identity);
            bullet.Launch(_projectileSpawnPoint.position, _projectileSpawnPoint.rotation, isPlayerLaunched);
            yield return _waitForFireRate;
            _canShoot = true;
        }
    }
}