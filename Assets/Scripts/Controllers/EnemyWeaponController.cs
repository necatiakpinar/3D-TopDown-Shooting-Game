using System.Collections.Generic;
using Abstracts;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class EnemyWeaponController : MonoBehaviour
    {
        [SerializeField] private List<BaseWeapon> _ownedWeaponsPF;
        private List<BaseWeapon> _ownedWeapons;

        [SerializeField] [ReadOnly] private BaseWeapon _selectedWeapon;

        private bool _isInitialized;

        public BaseWeapon SelectedWeapon => _selectedWeapon;
        
        public void Init(Transform weaponGripParent)
        {
            if (_isInitialized)
            {
                var randomWeaponIndexRange = Random.Range(0, _ownedWeapons.Count);
                SelectWeapon(randomWeaponIndexRange);    
                return;
            }
            
            _ownedWeapons = new List<BaseWeapon>();
            for (int i = 0; i < _ownedWeaponsPF.Count; i++)
            {
                var weapon = Instantiate(_ownedWeaponsPF[i], weaponGripParent);
                weapon.transform.localPosition = Vector3.zero;
                weapon.gameObject.SetActive(false);
                _ownedWeapons.Add(weapon);
            }    
            _isInitialized = true;
            
            
            var randomWeaponIndex = Random.Range(0, _ownedWeapons.Count);
            SelectWeapon(randomWeaponIndex);
        }
        
        public void TryToShoot()
        {
            if (_selectedWeapon == null)
            {
                Debug.LogError("No weapon selected!");
                return;
            }
            
            if (_selectedWeapon.CanShoot)
                StartCoroutine(_selectedWeapon.TryShoot(false));
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
    }
}