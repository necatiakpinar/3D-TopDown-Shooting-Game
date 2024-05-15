using System;
using Enums;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        private Transform _followTarget;
        private Vector3 _offset;
        private void OnEnable()
        {
            Action<object[]> onFollowTargetSelectedAction = (parameters) => SetCameraFollowTarget((Transform)parameters[0]);
            EventManager.Subscribe(ActionType.OnFollowTargetSelected, onFollowTargetSelectedAction);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe(ActionType.OnFollowTargetSelected);
        }

        private void LateUpdate()
        {
            TryFollowToTarget();
        }

        private void TryFollowToTarget()
        {
            if (_followTarget == null)
                return;
            
            Vector3 desiredPosition = _followTarget.position + _offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
        }
        private void SetCameraFollowTarget(Transform target)
        {
            _followTarget = target;
            _offset = transform.position - _followTarget.position;
        }
    }
}
