using Abstracts;
using UnityEngine;
using UnityEngine.Serialization;

namespace WeaponUpgrades
{
    public class WeaponScopeUpgrade : BaseWeaponUpgrade
    {
        public override void AttachToWeapon(BaseWeapon weapon)
        {
            weapon.GameplayAttributes.Range += _upgradeAttributesData.IncraseAmount;
        }
    }
}