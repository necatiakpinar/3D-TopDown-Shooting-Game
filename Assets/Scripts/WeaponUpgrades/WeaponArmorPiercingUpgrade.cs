using Abstracts;
using UnityEngine;

namespace WeaponUpgrades
{
    public class WeaponArmorPiercingUpgrade : BaseWeaponUpgrade
    {
        public override void AttachToWeapon(BaseWeapon weapon)
        {
            weapon.GameplayAttributes.Damage.ArmorPenetration += _upgradeAttributesData.IncraseAmount;
        }
    }
}