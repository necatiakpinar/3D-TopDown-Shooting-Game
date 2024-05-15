using Abstracts;
using Enums;
using Misc;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Enemy
{
    public class PatrolAIState : BaseAIState
    {
        private readonly float _patrolStopDistance = 0.1f;
        public PatrolAIState(BaseEnemy enemy) : base(enemy)
        {
        }
        
        public override void Enter(AIStateParameters stateParameters = null)
        {
            Vector3 randomPoint = GetRandomPointOnNavMesh();
            _enemy.Agent.SetDestination(randomPoint);
        }

        public override void Update()
        {
            if (!_enemy.Agent.pathPending && _enemy.Agent.remainingDistance < _patrolStopDistance && !_enemy.Agent.isStopped)
                Exit();
        }

        public override void Exit()
        {
            _enemy.AIController.SetState(AIStateType.Idle);
        }
        
        Vector3 GetRandomPointOnNavMesh()
        {
            NavMeshHit hit;
            Vector3 randomPoint = Vector3.zero;
            
            if (NavMesh.SamplePosition(Random.insideUnitSphere * 10f + _enemy.transform.position, out hit, 10f, NavMesh.AllAreas))
                randomPoint = hit.position;

            return randomPoint;
        }
    }
}