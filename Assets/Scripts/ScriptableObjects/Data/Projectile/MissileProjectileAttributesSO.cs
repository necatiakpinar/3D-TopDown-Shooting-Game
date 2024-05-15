using UnityEngine;

namespace ScriptableObjects.Data.Projectile
{
    [CreateAssetMenu(fileName = "MissileProjectileAttributes", menuName = "Data/Projectile/MissileProjectileAttributes")]
    public class MissileProjectileAttributesSO : BaseProjectileAttributesSO
    {
        [SerializeField] private float _araaOfEffectRadius;

        public float AreaOfEffectRadius => _araaOfEffectRadius;
    }
}