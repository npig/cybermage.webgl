using UnityEngine;
using UnityEngine.AI;

namespace Cybermage.Common
{
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
        }

        public static void Update()
        {
            CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, InputController.MoveInput * 1.35f, Time.deltaTime);
            Player.transform.position += CurrentVelocity * Time.deltaTime;
           
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