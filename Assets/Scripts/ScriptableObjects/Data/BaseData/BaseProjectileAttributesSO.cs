using UnityEngine;

namespace ScriptableObjects.Data.Projectile
{
    public abstract class BaseProjectileAttributesSO : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime = 4; 
        public float Speed => _speed;
        public float LifeTime => _lifeTime;
    }
}