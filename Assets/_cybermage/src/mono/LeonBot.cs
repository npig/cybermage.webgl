using System.Collections;
using System.Collections.Generic;
using Cybermage;
using UnityEngine;

public class LeonBot : MonoBehaviour
{
    public float _speed = 5f;

    void Update()
    {
        if(GlobalsConfig.GameState != GameState.Active)
            return;

        Vector3 playerPosition = GlobalsConfig.Player.GetPosition();
        Vector3 worldDeltaPosition = (transform.position - playerPosition).normalized;
        float dx = Vector3.Dot (transform.right, worldDeltaPosition);
        float dy = Vector3.Dot (transform.up, worldDeltaPosition);
        float dz = Vector3.Dot (transform.forward, worldDeltaPosition);
        Vector3 delta = new Vector3(dx, dy, dz);
        Vector3 move = transform.position - delta * (Time.deltaTime * _speed);
        transform.position = new Vector3(move.x, playerPosition.y + 2, move.z );
        
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, delta, Time.deltaTime * _speed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        Debug.DrawLine(transform.position, transform.position - delta, Color.red);
        
        Hover();
    }
    
    private void Hover()
    {
        float f = Mathf.Sin(Time.deltaTime * .01f);
        transform.position += new Vector3(0, 0 + f, 0);
    }
}
