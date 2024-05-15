using UnityEngine;

namespace ScriptableObjects.Data.BaseData
{
    public abstract class BaseActorAttributesSO : ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 5;

        public float MoveSpeed => _moveSpeed;
    }
}