using System;
using UnityEngine;

namespace Cybermage.Common
{
    public class Pickup : MonoBehaviour
    {
        private Vector3 _rotationAngle = new Vector3(1,1,0);
        private void Update()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (_rotationAngle * .1f));
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerController pc = other.GetComponent<PlayerController>();

            if (pc == null) 
                return;
            
            pc._mobileData.Heal(15);
            Destroy(gameObject);
        }
    }
}