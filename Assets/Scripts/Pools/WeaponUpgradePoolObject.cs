using System;
using Abstracts;
using Enums;
using UnityEngine;

namespace Pools
{
    [Serializable]
    public class WeaponUpgradePoolObject
    {
        [SerializeField] private WeaponAttachmentType _upgradeType;
        [SerializeField] private BaseWeaponUpgrade _weaponUpgradePF;
        [SerializeField] private int _size;

        public WeaponAttachmentType UpgradeType => _upgradeType;
        public BaseWeaponUpgrade WeaponUpgradePF => _weaponUpgradePF;
        public int Size => _size;
    }
}