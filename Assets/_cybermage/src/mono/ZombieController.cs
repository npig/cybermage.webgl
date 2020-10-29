
using UnityEngine;

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
            base.Update();
        }
        
        
    }
}