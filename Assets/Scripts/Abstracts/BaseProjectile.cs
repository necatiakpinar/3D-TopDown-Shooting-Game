using Enums;
using Interfaces;
using Managers;
using Misc;
using ScriptableObjects.Data.Projectile;
using UnityEngine;

namespace Abstracts
{
    public abstract class BaseProjectile : MonoBehaviour, IPoolable
    {
        [SerializeField] protected BaseProjectileAttributesSO _projectileAttributeData;
        [SerializeField] private ProjectileType _projectileType;
        
        private bool _isPlayerLaunched;
        private bool _isLaunched;
        private float _distanceTravelled;
        private BaseWeapon _launchedWeapon;
        
        public virtual void Init(BaseWeapon weapon)
        {
            _launchedWeapon = weapon;
            _distanceTravelled = 0;
        }
        
        public void Update()
        {
            if (!_isLaunched)
                return;
            
            transform.Translate(Vector3.forward * (_projectileAttributeData.Speed * Time.deltaTime));
            _distanceTravelled += Time.deltaTime * _projectileAttributeData.Speed;
            
            if (_distanceTravelled >= _launchedWeapon.GameplayAttributes.Range)
                ReturnToPool();
        }

        public virtual void Launch(Vector3 weaponPosition, Quaternion weaponRotation, bool isPlayerLaunched)
        {
            transform.position = weaponPosition;
            transform.rotation = weaponRotation;
            _isLaunched = true;
            _isPlayerLaunched = isPlayerLaunched;
            
           Invoke(nameof(ReturnToPool), _projectileAttributeData.LifeTime);
        }
        
        public void OnTriggerEnter(Collider collider)
        {
            if (_isPlayerLaunched && collider.gameObject.layer == LayerMask.NameToLayer(Constants.LayerEnemy))
            {
                collider.GetComponentInParent<IDamageable>().TakeDamage(_launchedWeapon.GameplayAttributes.Damage);
                ReturnToPool();
            }
            else if (collider.gameObject.layer == LayerMask.NameToLayer(Constants.LayerPlayer))
            {
                collider.GetComponentInParent<IDamageable>().TakeDamage(_launchedWeapon.GameplayAttributes.Damage);
                ReturnToPool();
            }
        }
        public void ResetObject()
        {
            _distanceTravelled = 0;
            _isLaunched = false;
            gameObject.SetActive(false);
        }

        public void ReturnToPool()
        {
            ProjectilePoolManager.Instance.ReturnToPool(_projectileType, this);
        }
    }
}