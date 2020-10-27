
using Cybermage.Events;
using UnityEngine;

namespace Cybermage.Common
{
    public class MouseHitPoint : IEvent
    {
        public Vector3 HitPoint { get; private set; }
        
        public MouseHitPoint(Vector3 hitPoint)
        {
            HitPoint = hitPoint;
        }
    }
    
    public static class InputController
    {
        private static float _inputHorizontal = 0;
        private static float _inputVertical = 0;
        private static float _inputAimHorizontal = 0;
        private static float _inputAimVertical = 0;
        private static  bool _inputDeath;
        private static  bool _inputCastL;
        private static  bool _inputCastR;
        private static  bool _inputRelax;
        
        
        public static bool allowedInput { get; set; }
        public static Vector3 MoveInput { get; set; }
        public static Vector2 AimInput { get; set; }
        
        
        public static void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Physics.Raycast(
                    MainCamera.Camera.ScreenPointToRay(Input.mousePosition), 
                    out RaycastHit hit, 
                    Mathf.Infinity, 
                    1 << 8);
                {
                    EventManager.Instance.Raise(new MouseHitPoint(hit.point));
                }
            }
        }

        private static void Inputs()
        {
   
        }
    }
}