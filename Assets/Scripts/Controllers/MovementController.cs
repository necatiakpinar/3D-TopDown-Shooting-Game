using Abstracts;
using Enums;
using UnityEngine;
using UnityEngine.AI;

namespace Controllers
{
    public class MovementController
    {
        private BasePlayer _player;
        private NavMeshAgent _agent;
        private Camera _mainCam;

        private readonly string _horizontalInput = "Horizontal";
        private readonly string _verticalInput = "Vertical";
        
        public MovementController(BasePlayer player)
        {
            _player = player;
            _agent = _player.GetComponent<NavMeshAgent>();
            _agent.baseOffset = _player.transform.position.y;
            _mainCam = Camera.main;
            
            EventManager.Notify(ActionType.OnFollowTargetSelected, new object[]{_player.transform});
        }
        
        public void UpdateMovement()
        {
            float horizontalInput = Input.GetAxisRaw(_horizontalInput);
            float verticalInput = Input.GetAxisRaw(_verticalInput);
            
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
            Vector3 moveDestination = _player.transform.position + moveDirection.normalized * _player.PlayerAttributesData.MoveSpeed;
            
            _agent.SetDestination(moveDestination);
            
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 lookDirection = hit.point - _player.transform.position;
                lookDirection.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookDirection);
                _player.transform.rotation = rotation;
            }
        }
    }
}