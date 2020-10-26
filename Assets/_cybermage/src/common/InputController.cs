
using UnityEngine;

namespace Cybermage.Common
{
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
            Inputs();
            MoveInput = CameraRelativeInput(_inputHorizontal, _inputVertical);
            AimInput = new Vector2(_inputAimHorizontal, _inputAimVertical);
        }

        private static void Inputs()
        {
            _inputHorizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
            _inputVertical = UnityEngine.Input.GetAxisRaw("Vertical");
            //_inputAimVertical = UnityEngine.Input.GetAxisRaw("AimVertical");
            //_inputAimHorizontal = UnityEngine.Input.GetAxisRaw("AimHorizontal");
        }
        
        private static Vector3 CameraRelativeInput(float inputX, float inputZ)
        {
            //Forward vector relative to the camera along the x-z plane   
            Vector3 forward = MainCamera.Camera.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;
            //Right vector relative to the camera always orthogonal to the forward vector.
            Vector3 right = new Vector3(forward.z, 0, -forward.x);
            Vector3 relativeVelocity = _inputHorizontal * right + _inputVertical * forward;
            //Reduce input for diagonal movement.
            if(relativeVelocity.magnitude > 1)
            {
                relativeVelocity.Normalize();
            }
            return relativeVelocity;
        }
    }
}