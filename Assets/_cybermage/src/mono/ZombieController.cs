
using UnityEngine;
using UnityEngine.AI;

namespace Cybermage.Common
{
    public class ZombieController : MobileController
    {
        public override void Awake()
        {
            base.Awake();
            Utilities.FindDeepChild<ColliderComponent>(
                this.transform, 
                "spine_01")
                .SetMobileController(this);
        }

        public override void Update()
        {
            if (_isLocked || _isDead) 
                return;
            
            if (_agent.pathPending ||
                _agent.pathStatus == NavMeshPathStatus.PathInvalid ||
                _agent.path.corners.Length == 0)
                return;
            
            base.Update();
            ProximityCheck();
            
            if (_target != null && _agent.remainingDistance < _mobileData.GetData().AttackRange)
            {
                _animator.SetBool("Moving", false);
                _animator.SetTrigger("Attack");
                
                Lock(0, 10, () =>
                {
                    _target = null;
                });
            }
        }

        private void ProximityCheck()
        {
            Vector3 playerPosition = EntityFactory.Player.GetPosition();
            float playerDistance = (transform.position - playerPosition).magnitude;
            
            if (playerDistance <= _mobileData.GetData().AlertRange)
            {
                _target = EntityFactory.Player;
                _agent.destination = playerPosition;
            }
            else
            {
                _target = null;
                _agent.ResetPath();
            }
        }
    }
}