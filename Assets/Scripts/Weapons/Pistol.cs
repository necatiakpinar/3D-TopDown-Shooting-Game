using System.Collections;
using System.Collections.Generic;
using Abstracts;
using Data;
using Enums;
using Managers;
using UnityEngine;

namespace Weapons
{
    public class Pistol : BaseWeapon
    {
        protected override void SetupAttachments()
        {
            var barrelAttachment = new WeaponAttachment(WeaponAttachmentType.Barrel);
            var scopeAttachment = new WeaponAttachment(WeaponAttachmentType.Scope);

            _weaponAttachments = new List<WeaponAttachment>();
            _weaponAttachments.Add(barrelAttachment);
            _weaponAttachments.Add(scopeAttachment);
        }

        public override IEnumerator TryShoot(bool isPlayerLaunched)
        {   
            _canShoot = false;
            var bullet = ProjectilePoolManager.Instance.SpawnFromPool(_projectileType,this, _projectileSpawnPoint.transform.position, Quaternion.identity);
            bullet.Launch(_projectileSpawnPoint.position, _projectileSpawnPoint.rotation, isPlayerLaunched);
            yield return _waitForFireRate;
            _canShoot = true;
        }
    }
}