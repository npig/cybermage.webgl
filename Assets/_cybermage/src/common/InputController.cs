
using Cybermage.Events;
using UnityEngine;

namespace Cybermage.Common
{
    public class MouseHitPoint : IEvent
    {
        public Vector3 HitPoint { get; private set; }
        public Collider Collider { get; private set; }
        
        public MouseHitPoint(Vector3 hitPoint, Collider collider = null)
        {
            HitPoint = hitPoint;
            Collider = collider;
        }
    }
    
    public static class InputController
    {
        
        public static void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Physics.Raycast(
                    MainCamera.Camera.ScreenPointToRay(Input.mousePosition), 
                    out RaycastHit hit, Mathf.Infinity, 1 << 8);
                {
                    if(hit.point != Vector3.zero)
                        EventManager.Instance.Raise(new MouseHitPoint(hit.point, hit.collider));
                }
            }
        }

        private static void Inputs()
        {
   
        }
    }
}