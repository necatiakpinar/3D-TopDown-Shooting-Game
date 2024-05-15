using Abstracts;
using UnityEngine;

namespace WeaponUpgrades
{
    public class WeaponBarrelUpgrade : BaseWeaponUpgrade
    {
        public override void AttachToWeapon(BaseWeapon weapon)
        {
            weapon.GameplayAttributes.Damage.HealthDamage += _upgradeAttributesData.IncraseAmount;
        }
    }
}