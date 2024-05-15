using Abstracts;
using Misc;

namespace AI.Enemy
{
    public class AttackAIState : BaseAIState
    {
        private BasePlayer _player;
        public AttackAIState(BaseEnemy enemy) : base(enemy)
        {
        }
        public override void Enter(AIStateParameters stateParameters = null)
        {
            if (stateParameters != null)
                _player = stateParameters.Player;
        }

        public override void Update()
        {
            if (_player != null)
            {
                _enemy.Agent.SetDestination(_player.transform.position);
                _enemy.WeaponController.TryToShoot();
            }
        }

        public override void Exit()
        {
        }
    }
}