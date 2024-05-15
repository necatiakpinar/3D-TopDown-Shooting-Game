using System.Collections.Generic;
using Abstracts;
using UnityEngine;

namespace Controllers
{
    public class WeaponController : MonoBehaviour
    { 
        [SerializeField] private List<BaseWeapon> _ownedWeaponsPF;
        
        private List<BaseWeapon> _ownedWeapons;
        private BaseWeapon _selectedWeapon;
        private bool _isInitialized;

        public BaseWeapon SelectedWeapon => _selectedWeapon;
        public void Init(Transform weaponGripParent)
        {
            if (_isInitialized)
                return;
            
            _ownedWeapons = new List<BaseWeapon>();
            for (int i = 0; i < _ownedWeaponsPF.Count; i++)
            {
                var weapon = Instantiate(_ownedWeaponsPF[i], weaponGripParent);
                weapon.transform.localPosition = Vector3.zero;
                weapon.gameObject.SetActive(false);
                _ownedWeapons.Add(weapon);
            }    
            _isInitialized = true;
            
            SelectWeapon(0);
        }
        
        void Update()
        {
            if (!_isInitialized)
                return;

            CheckForSelectingWeapons();
            CheckForShooting();
        }

        private void CheckForSelectingWeapons()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SelectWeapon(0);
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
                SelectWeapon(1);
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
                SelectWeapon(2);

        }

        private void CheckForShooting()
        {
            if (_selectedWeapon == null)
            {
                Debug.LogError("No weapon selected!");
                return;
            }
            
            if (Input.GetMouseButton(0) && _selectedWeapon.CanShoot)
                StartCoroutine(_selectedWeapon.TryShoot(true));
        }
        
        private void SelectWeapon(int weaponIndex)
        {
            if (weaponIndex < 0 || weaponIndex >= _ownedWeapons.Count)
            {
                Debug.LogError("Invalid weapon index!");
                return;
            }
            
            _ownedWeapons.ForEach(weapon => weapon.gameObject.SetActive(false));
            
            _selectedWeapon = _ownedWeapons[weaponIndex];
            _selectedWeapon.gameObject.SetActive(true);

        }
        
        public void ResetAllWeapons()
        {
            _ownedWeapons.ForEach(weapon => weapon.ResetAllAttachments());
        }
    }
}