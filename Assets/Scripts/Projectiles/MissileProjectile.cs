using System;
using Abstracts;
using ScriptableObjects.Data.Projectile;
using UnityEngine;

namespace Projectiles
{
    public class MissileProjectile : BaseProjectile
    {
        private SphereCollider _collider;
        private MissileProjectileAttributesSO _missileProjectileAttributesData;

        private void Awake()
        {
            _missileProjectileAttributesData = (MissileProjectileAttributesSO) _projectileAttributeData;
            _collider = GetComponent<SphereCollider>();
            _collider.radius = _missileProjectileAttributesData.AreaOfEffectRadius;
        }
    }
}