using System;
using Abstracts;
using Enums;
using UnityEngine;

namespace Pools
{
    [Serializable]
    public class ProjectilePoolObject
    {
        [SerializeField] private ProjectileType _projectileType;
        [SerializeField] private BaseProjectile _projectilePF;
        [SerializeField] private int _size;

        public ProjectileType ProjectileType => _projectileType;
        public BaseProjectile ProjectilePF => _projectilePF;
        public int Size => _size;
    }
}