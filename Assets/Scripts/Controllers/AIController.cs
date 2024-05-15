using Abstracts;
using AI.Enemy;
using Enums;
using Misc;

namespace Controllers
{
    public class AIController
    {
        private IdleAIState _idleAIState;
        private PatrolAIState _patrolAIState;
        private AttackAIState _attackAIState;
        private BaseAIState _currentState;
        
        private BaseEnemy _enemy;

        public AIController(BaseEnemy enemy)
        {
            _enemy = enemy;
            
            _idleAIState = new IdleAIState(enemy);
            _patrolAIState = new PatrolAIState(enemy);
            _attackAIState = new AttackAIState(enemy);
            
            SetState(AIStateType.Patrol);
        }
        
        public void SetState(AIStateType stateType, AIStateParameters stateParameters = null)
        {
            switch (stateType)
            {
                case AIStateType.Idle:
                    _currentState = _idleAIState;
                    break;
                case AIStateType.Patrol:
                    _currentState = _patrolAIState;
                    break;
                case AIStateType.Attack:
                    _currentState = _attackAIState;
                    break;
            }
            
            _currentState.Enter(stateParameters);
        }
        
        public void Update()
        {
            _currentState.Update();
        }
    }
}