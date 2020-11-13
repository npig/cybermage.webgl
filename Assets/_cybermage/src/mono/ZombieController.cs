
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
            if (_isLocked || _isDead || EntityFactory.Player._isDead) 
                return;
            
            if (_agent.pathPending ||
                _agent.pathStatus == NavMeshPathStatus.PathInvalid ||
                _agent.path.corners.Length == 0)
                return;
            
            base.Update();
            
            Vector3 playerPosition = EntityFactory.Player.GetPosition();
            float playerDistance = (transform.position - playerPosition).magnitude;
            ProximityCheck(playerDistance, playerPosition);
            
            if (_target != null && playerDistance <= _mobileData.GetData().AttackRange)
            {
                _animator.SetBool("Moving", false);
                _animator.SetTrigger("Attack");
                
                Lock(20, () =>
                {
                    _target = null;
                    _agent.ResetPath();
                });
            }
        }

        private void ProximityCheck(float distance, Vector3 playerPosition)
        {
            if (distance <= _mobileData.GetData().AlertRange)
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
        
        public override void Shoot()
        {
            base.Shoot();
            
        }
    }
}