using Abstracts;
using Enums;
using Misc;
using UnityEngine;

namespace Controllers
{
    public class PlayerDetectorController : MonoBehaviour
    {
        private BaseEnemy _enemy;

        private void Awake()
        {
            _enemy = GetComponentInParent<BaseEnemy>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer(Constants.LayerPlayer))
            {
                var player = collider.GetComponentInParent<BasePlayer>();
                if (player != null)
                {
                    AIStateParameters aiStateParameters = new AIStateParameters(player);
                    _enemy.AIController.SetState(AIStateType.Attack, aiStateParameters);    
                }
            }
        }
        
        private void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer(Constants.LayerPlayer))
            {
                _enemy.AIController.SetState(AIStateType.Patrol);
            }
        }
    }
}