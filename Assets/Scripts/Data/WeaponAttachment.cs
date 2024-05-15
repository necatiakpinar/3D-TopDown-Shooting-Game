using System;
using Enums;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class WeaponAttachment
    {
        [SerializeField] private WeaponAttachmentType _weaponAttachmentType;
        [SerializeField] private bool _isAttached;

        public WeaponAttachmentType WeaponAttachmentType => _weaponAttachmentType;
        public bool IsAttached => _isAttached;
        
        public WeaponAttachment(WeaponAttachmentType weaponAttachmentType)
        {
            _weaponAttachmentType = weaponAttachmentType;
            _isAttached = false;
        }

        public void SetAttachment(bool isAttached)
        {
            _isAttached = isAttached;
        }
    }
}