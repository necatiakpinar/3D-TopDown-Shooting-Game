using Data;
using UnityEngine;

namespace ScriptableObjects.Data.BaseData
{
    public abstract class BaseWeaponAttributesSO : ScriptableObject
    {
        [SerializeField] private WeaponDamage _damage;
        [SerializeField] private float _fireRate;
        [SerializeField] private float _range;
      
        public WeaponDamage Damage => _damage;
        public float FireRate => _fireRate;
        public float Range => _range;
        
    }
}