using Misc;

namespace Abstracts
{
    public abstract class BaseAIState
    {
        protected BaseEnemy _enemy;
        
        public BaseAIState(BaseEnemy enemy)
        {
            _enemy = enemy;
        }
        public abstract void Enter(AIStateParameters stateParameters = null);
        public abstract void Update();
        public abstract void Exit();
        
    }
}