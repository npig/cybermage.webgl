using Cybermage.Events;
using UnityEngine;
using UnityEngine.AI;

namespace Cybermage.Common
{
    public class PlayerController : MobileController
    {
        public override void Awake()
        {
            base.Awake();
            EventManager.Instance.AddListener<MouseHitPoint>(MouseHitPoint);
        }

        public override void Update()
        {
            base.Update();

            if (_target != null)
            {
                if (_agent.pathPending ||
                    _agent.pathStatus == NavMeshPathStatus.PathInvalid ||
                    _agent.path.corners.Length == 0)
                    return;
                
                if (_agent.remainingDistance < _mobileData.GetData().Range)
                {
                    _agent.ResetPath();
                    Debug.Log($"Attacking {_target.GetData().EntityType}");
                }
            }
        }

        private void MouseHitPoint(MouseHitPoint e)
        {
            _agent.ResetPath();
            _target = null;

            ColliderComponent colliderComponent = e.Collider.GetComponent<ColliderComponent>();
            
            if (colliderComponent != null)
            {
                _target = colliderComponent.GetMobile();
                _agent.destination = _target.GetPosition();
                return;
            }
            
            _agent.destination = e.HitPoint;
        }
    }
}