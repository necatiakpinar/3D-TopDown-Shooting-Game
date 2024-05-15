using System;
using UnityEngine;

namespace ScriptableObjects.Data.BaseData
{
    public abstract class BaseDamageableActorAttributesSO : BaseActorAttributesSO
    {
        [SerializeField] private float _health = 100;
        [SerializeField] private float _armor = 100;

        public float Health => _health;
        public float Armor => _armor;
        
    }
}