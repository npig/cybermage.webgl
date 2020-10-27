using Cybermage.Events;
using UnityEngine;
using UnityEngine.AI;

namespace Cybermage.Common
{
    public enum CharacterState
    {
        Idle = 0,
        Move = 1,
    }
    
    public static class CharacterController
    {
        public static GameObject Player;
        public static Animator Animator;
        public static NavMeshAgent NavMeshAgent;
        public static bool IsCasting;
        public static bool IsStrafing = false;
        public static bool IsSitting = false;
        public static Vector3 CurrentVelocity;


        public static void Initialise()
        {
            Player = GameObject.FindObjectOfType<Player>().gameObject;
            NavMeshAgent = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
            Animator = Player.GetComponent<Animator>();
            EventManager.Instance.AddListener<MouseHitPoint>(MouseHitPoint);
        }

        private static void MouseHitPoint(MouseHitPoint e)
        {
            NavMeshAgent.destination = e.HitPoint;
        }

        public static void Update()
        {
            if(NavMeshAgent != null)
            {
                if(NavMeshAgent.velocity.sqrMagnitude > 0)
                {
                    Animator.SetBool("Moving", true);
                    Animator.SetFloat("Velocity Z", NavMeshAgent.velocity.magnitude);
                }
                else
                {
                    Animator.SetFloat("Velocity Z", 0);
                }
            }
        }
    }
}