using Interfaces;
using Managers;
using Misc;
using ScriptableObjects.Data.BaseData;
using TMPro;
using UnityEngine;

namespace Abstracts
{
    public abstract class BaseWeaponUpgrade : MonoBehaviour, IPoolable
    {
        [SerializeField] protected BaseWeaponUpgradeAttributesSO _upgradeAttributesData;
        [SerializeField] private TMP_Text _upgradeName;

        private Camera _mainCamera;
        private Transform _cachedTransform;
        
        public abstract void AttachToWeapon(BaseWeapon weapon);

        private void Start()
        {
            _mainCamera = Camera.main;
            _cachedTransform = _upgradeName.transform;
            _upgradeName.text = _upgradeAttributesData.AttachmentType.ToString();
        }
        
        public void Init()
        {
            
        }
        void LateUpdate()
        {
            _cachedTransform.LookAt(_cachedTransform.position + _mainCamera.transform.rotation * Vector3.forward,
                _mainCamera.transform.rotation * Vector3.up);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer(Constants.LayerPlayer))
            {
                var selectedWeapon = collider.GetComponentInParent<BasePlayer>().WeaponController.SelectedWeapon;
                if (selectedWeapon == null)
                    Debug.LogError("No weapon selected!");

                bool canAttach;
                selectedWeapon.TryUseAttachment(_upgradeAttributesData.AttachmentType, out canAttach);

                if (!canAttach)
                    return;
                
                AttachToWeapon(selectedWeapon);
                WeaponUpgradePoolManager.Instance.ReturnToPool(_upgradeAttributesData.AttachmentType,this);
            }
        }

        public void ResetObject()
        {
            gameObject.SetActive(false);
        }
    }
}