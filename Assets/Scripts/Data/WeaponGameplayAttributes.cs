using ScriptableObjects.Data.BaseData;
using ScriptableObjects.Data.Weapons;

namespace Data
{
    public class WeaponGameplayAttributes
    {
        public WeaponDamage Damage;
        public float FireRate;
        public float Range;
        
        public WeaponGameplayAttributes(BaseWeaponAttributesSO baseWeaponAttributes)
        {
            Damage = baseWeaponAttributes.Damage;
            FireRate = baseWeaponAttributes.FireRate;
            Range = baseWeaponAttributes.Range;
        }
    }
}