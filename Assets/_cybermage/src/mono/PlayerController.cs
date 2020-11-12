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

        public void Start()
        {
            //_animator.SetInteger("Weapon", -1);
            //_animator.SetInteger("Weapon", 0);
        }

        public override void Update()
        {
            if (_isLocked || _isDead) 
                return;
            
            base.Update();
            
            if (_target != null && !_isLocked)
            {
                if (_agent.remainingDistance < _mobileData.GetData().AlertRange)
                {
                    _agent.ResetPath();
                    _animator.SetBool("Moving", false);
                    _animator.SetTrigger("Attack");

                    Lock(0, 10, () =>
                    {
                        _target = null;
                    });
                }
            }
        }

        private void MouseHitPoint(MouseHitPoint e)
        {
            //_agent.ResetPath();
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

        public override void Shoot()
        {
            base.Shoot();
            
            Transform transform = Instantiate(CM_Resources.prefabs.vfx.superCyberFire.Load(), _target.GetTransform()).transform;
            transform.position = _target.GetPosition();
        }
    }
}