using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data;
using Enums;
using ScriptableObjects.Data.BaseData;
using UnityEngine;

namespace Abstracts
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        [SerializeField] protected BaseWeaponAttributesSO _attributesData;
        [SerializeField] protected List<WeaponAttachment> _weaponAttachments; 
        [SerializeField] protected Transform _projectileSpawnPoint;
        [SerializeField] protected ProjectileType _projectileType;

        protected WaitForSeconds _waitForFireRate;
        protected bool _canShoot;
        
        protected WeaponGameplayAttributes _gameplayAttributes;
        public WeaponGameplayAttributes GameplayAttributes => _gameplayAttributes;
        public bool CanShoot => _canShoot;

        private void OnEnable()
        {
            _canShoot = true;
        }

        protected virtual void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            _gameplayAttributes = new WeaponGameplayAttributes(_attributesData);
            _canShoot = true; 
            _waitForFireRate = new WaitForSeconds(_gameplayAttributes.FireRate);
            SetupAttachments();
        }

        protected abstract void SetupAttachments();
        public abstract IEnumerator TryShoot(bool isPlayerLaunched);
        
        public void TryUseAttachment(WeaponAttachmentType attachmentType, out bool isAttached)
        {
            var availableAttachment = _weaponAttachments.FirstOrDefault(attachment => attachment.WeaponAttachmentType == attachmentType && !attachment.IsAttached);
            if (availableAttachment == null)
            {
                isAttached = false;
            }
            else
            {
                isAttached = true;
                availableAttachment.SetAttachment(true);
            }
        }
        
        public void ResetAllAttachments()
        {
            foreach (var attachment in _weaponAttachments)
                attachment.SetAttachment(false);
        }
    }
}