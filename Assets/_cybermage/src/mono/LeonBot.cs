using System.Collections;
using System.Collections.Generic;
using Cybermage;
using UnityEngine;

public class LeonBot : MonoBehaviour
{
    [SerializeField] private float _range = 5;
    // Update is called once per frame
    private void Update()
    {
        if(GlobalsConfig.GameState != GameState.Active)
            return;
        
        Vector3 deltaPosition = transform.position - GlobalsConfig.Player.GetPosition();

        if (deltaPosition.magnitude > _range)
        {
            Debug.Log(transform.InverseTransformDirection(Vector3.forward));
            transform.position = transform.InverseTransformDirection(Vector3.forward) * 1f;
        }
        
        Quaternion faceDirection = Quaternion.LookRotation(deltaPosition.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, faceDirection, Time.deltaTime * 1);
    }
}
