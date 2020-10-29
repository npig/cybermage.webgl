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

        private void MouseHitPoint(MouseHitPoint e)
        {
            ColliderComponent colliderComponent = e.Collider.GetComponent<ColliderComponent>();
            
            if (colliderComponent != null)
            {
                Debug.Log($"attacking {colliderComponent.GetMobileController().name}");
                return;
            }
            
            _agent.destination = e.HitPoint;
        }
    }
}