using System;
using Abstracts;
using Enums;
using UnityEngine;

namespace Pools
{
    [Serializable]
    public class EnemyPoolObject
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private BaseEnemy _enemyPF;
        [SerializeField] private int _size;

        public EnemyType EnemyType => _enemyType;
        public BaseEnemy EnemyPf => _enemyPF;
        public int Size => _size;

    }
}