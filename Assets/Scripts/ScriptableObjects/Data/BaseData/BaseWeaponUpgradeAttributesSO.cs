using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects.Data.BaseData
{
    public abstract class BaseWeaponUpgradeAttributesSO : ScriptableObject
    {
        [SerializeField] private WeaponAttachmentType _attachmentType;
        [SerializeField] private float _incraseAmount;
        
        public WeaponAttachmentType AttachmentType => _attachmentType;
        public float IncraseAmount => _incraseAmount;
    }
}