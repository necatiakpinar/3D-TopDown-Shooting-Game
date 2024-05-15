using Controllers;
using Data;
using Interfaces;
using ScriptableObjects.Data.Players;
using UnityEngine;
using UnityEngine.AI;

namespace Abstracts
{
    public abstract class BasePlayer : BaseActor, IDamageable
    {
        [SerializeField] protected BasicPlayerAttributesSO _playerAttributesData;
        [SerializeField] protected ActorGameplayAttributes _gameplayAttributesData;
        [SerializeField] protected Transform _weaponGripTransform;
        [SerializeField] protected WeaponController _weaponController;

        private MovementController _movementController;
        
        public BasicPlayerAttributesSO PlayerAttributesData => _playerAttributesData;
        public WeaponController WeaponController => _weaponController;

        protected override void Start()
        {
            base.Start();
            Init();
        }

        private void Update()
        {
            _movementController.UpdateMovement();
        }

        public override void Init()
        {
            base.Init();
            _movementController = new MovementController(this);
            _gameplayAttributesData = new ActorGameplayAttributes(_playerAttributesData);
            _weaponController.Init(_weaponGripTransform);
            var startingPoint = GetRandomPointOnNavMesh();
            transform.position = startingPoint;
        }

        public void TakeDamage(WeaponDamage weaponDamage)
        {
            if (_gameplayAttributesData.CurrentArmor > weaponDamage.ArmorPenetration)
            {
                _gameplayAttributesData.CurrentArmor -= weaponDamage.ArmorPenetration;
                _gameplayAttributesData.CurrentHealth -= weaponDamage.HealthDamage;
            }
            else
            {
                var remainingArmorPenetration = weaponDamage.ArmorPenetration - _gameplayAttributesData.CurrentArmor;
                _gameplayAttributesData.CurrentArmor = 0;

                var totalDamage = weaponDamage.HealthDamage + remainingArmorPenetration;
                _gameplayAttributesData.CurrentHealth -= totalDamage;
            }

            if (_gameplayAttributesData.CurrentHealth <= 0)
                Die();
        }

        public void Die()
        {
            _weaponController.ResetAllWeapons();
            Init();
        }
        
        Vector3 GetRandomPointOnNavMesh()
        {
            NavMeshHit hit;
            Vector3 randomPoint = Vector3.zero;
            
            if (NavMesh.SamplePosition(Random.insideUnitSphere * 30f, out hit, 30f, NavMesh.AllAreas))
                randomPoint = hit.position;

            return randomPoint;
        }

    }
}