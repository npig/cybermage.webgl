﻿using System.Collections;
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
        float f = (transform.position - playerPosition).magnitude;
        
        if (f < 2.5f)
            return;
        
        Vector3 worldDeltaPosition = (transform.position - playerPosition).normalized;
        float dx = Vector3.Dot (Vector3.right, worldDeltaPosition);
        float dy = Vector3.Dot (Vector3.up, worldDeltaPosition);
        float dz = Vector3.Dot (Vector3.forward, worldDeltaPosition);
        Vector3 delta = new Vector3(dx, dy, dz);
        Vector3 move = transform.position - delta * (Time.deltaTime * _speed);
        transform.position = new Vector3(move.x, playerPosition.y + 2, move.z );
        
        Quaternion q = Quaternion.LookRotation(new Vector3(delta.x, 0, delta.z));
        if(q.normalized != Quaternion.identity)
            transform.rotation = q;
        
        Hover();
    }
    
    private void Hover()
    {
        float f = Mathf.Sin(Time.deltaTime * .01f);
        transform.position += new Vector3(0, 0 + f, 0);
    }
}
