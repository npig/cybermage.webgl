using System;
using UnityEngine;

namespace Cybermage.Common
{
    public class CameraController : MonoBehaviour
    {
        private Transform _playerTransform;

        private Vector3 PlayerPosition()
        {
            if (_playerTransform == null)
            {
                if (GlobalsConfig.Player == null)
                    return Vector3.zero;
                
                _playerTransform = GlobalsConfig.Player.GetController().transform;
            }

            return _playerTransform.position;
        }
        
        private void LateUpdate()
        {
            this.transform.position = PlayerPosition();
        }
    }
}