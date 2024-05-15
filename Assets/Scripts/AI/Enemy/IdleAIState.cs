using System.Threading.Tasks;
using Abstracts;
using Enums;
using Misc;

namespace AI.Enemy
{
    public class IdleAIState : BaseAIState
    {
        public IdleAIState(BaseEnemy enemy) : base(enemy)
        {
        }
        public override void Enter(AIStateParameters stateParameters = null)
        {
            Wait();
        }

        public async Task Wait()
        {
            await Task.Delay(2000);
            Exit();
        }
        public override void Update()
        {
        }

        public override void Exit()
        {
            _enemy.AIController.SetState(AIStateType.Patrol);
        }
    }
}