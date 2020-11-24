
using Cybermage.Core;
using Cysharp.Threading.Tasks;
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
            if (_isLocked || _isDead || GlobalsConfig.Player._isDead) 
                return;
            
            if (_agent.pathPending ||
                _agent.pathStatus == NavMeshPathStatus.PathInvalid ||
                _agent.path.corners.Length == 0)
                return;
            
            base.Update();
            
            Vector3 playerPosition = GlobalsConfig.Player.GetPosition();
            float playerDistance = (transform.position - playerPosition).magnitude;
            ProximityCheck(playerDistance, playerPosition);
            
            if (_target != null && playerDistance <= _mobileData.AttackRange)
            {
                _agent.ResetPath();
                _agent.nextPosition = transform.position;
                _animator.SetTrigger("Attack");
                
                Lock(20, () =>
                {
                    _target = null;
                });
            }
        }

        private void ProximityCheck(float distance, Vector3 playerPosition)
        {
            if (distance <= _mobileData.AlertRange)
            {
                _target = GlobalsConfig.Player;
                _agent.destination = playerPosition;
            }
            else
            {
                _target = null;
                _agent.ResetPath();
            }
        }

        protected override void MobileDeath(DeathEvent e)
        {
            if (e.Mobile != _mobileData)
                return;
            
            _isDead = true;
            _agent.enabled = false;
            _animator.SetTrigger("Death");
            AudioManager.PlaySampleAtPosition("07_MAHURT1", transform.position);
            UnspawnZombie();
        }

        private async UniTaskVoid UnspawnZombie()
        {
            await UniTask.Delay(GlobalsConfig.CorpseRemoval);
            float time = 0;
            
            while (time < 720)
            {
                await UniTask.Delay(1);
                time++;
                transform.position += Vector3.down * .0005f; 
            }
            
            Destroy(gameObject);
        }

        public override void Shoot()
        {
            float distance = (transform.position - _target.GetPosition()).magnitude;

            if (_target == null || distance > _mobileData.AttackRange)
            {
                AudioManager.PlaySample("33_RM1HHI1");
                return;
            }
            
            AudioManager.PlaySample("29_HWREFLE7");
            base.Shoot();
        }
    }
}