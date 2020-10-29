using Cybermage.Events;
using UnityEngine;

namespace Cybermage.Common
{
    public class ColliderComponent : MonoBehaviour
    {
        private MobileController _mobileController;
       
        public MobileController GetMobileController()
        {
            return _mobileController;
        }

        public void SetMobileController(MobileController zombieController)
        {
            _mobileController = zombieController;
        }
    }
}
