using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class WeaponDamage
    {
        public float HealthDamage;
        public float ArmorPenetration;
        
        public WeaponDamage(float healthDamage, float armorPenetration)
        {
            HealthDamage = healthDamage;
            ArmorPenetration = armorPenetration;
        }
    }
}