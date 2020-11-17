﻿using System;
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

            if (GlobalsConfig.Dev)
                gameObject.AddComponent<NavPathDebug>();
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
            
            if (_target != null)
            {
                float distance = (_target.GetPosition() - transform.position).magnitude;
                if (distance < _mobileData.GetData().AlertRange)
                {
                    _agent.ResetPath();
                    _agent.nextPosition = transform.position;
                    _animator.SetTrigger("Attack");

                    Lock(10, () =>
                    {
                        _target = null;
                    });
                }
            }
        }

        private void MouseHitPoint(MouseHitPoint e)
        {
            if (_isLocked || _isDead) 
                return;
            
            _target = null;

            ColliderComponent colliderComponent = e.Collider.GetComponent<ColliderComponent>();
            
            if (colliderComponent != null )
            {
                if (!colliderComponent.GetMobile()._isDead)
                {
                    _target = colliderComponent.GetMobile();
                }
            }
            
            _agent.destination = e.HitPoint;
        }

        public override void Shoot()
        {
            base.Shoot();
            
            Transform transform = Instantiate(CM_Resources.prefabs.vfx.superCyberFire.Load(), _target.GetTransform()).transform;
            transform.position = _target.GetPosition();
        }
    }
}