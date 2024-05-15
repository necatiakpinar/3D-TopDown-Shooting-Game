using Controllers;
using Data;
using Enums;
using Interfaces;
using Managers;
using ScriptableObjects.Data.Enemies;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Abstracts
{
    public abstract class BaseEnemy : BaseActor, IDamageable, IPoolable
    {
        [SerializeField] private BasicEnemyAttributesSO _enemyAttributesData;
        [SerializeField] [ReadOnly] protected ActorGameplayAttributes _gameplayAttributesData;
        [Header("AI")] [SerializeField] private NavMeshAgent _agent;
        [Header("Weapon")] [SerializeField] protected Transform _weaponGripTransform;
        [SerializeField] private EnemyWeaponController _weaponController;

        private BaseWeapon _selectedWeapon;
        private AIController _aiController;

        public NavMeshAgent Agent => _agent;
        public AIController AIController => _aiController;
        public EnemyWeaponController WeaponController => _weaponController;

        public override void Init()
        {
            base.Init();
            _gameplayAttributesData = new ActorGameplayAttributes(_enemyAttributesData);
            _aiController = new AIController(this);
            _weaponController.Init(_weaponGripTransform);
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
            EventManager.Notify(ActionType.OnEnemyDead, this);
            EnemyPoolManager.Instance.ReturnToPool(EnemyType.BasicEnemy, this);
        }

        private void Update()
        {
            if (_aiController != null)
                _aiController.Update();
        }

        public void ResetObject()
        {
            gameObject.SetActive(false);
        }
    }
}