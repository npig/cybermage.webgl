using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private const float _rotationSpeed = 10f;
    
    private void Awake() 
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updatePosition = false;
    }
    
    private void Update() 
    {
        InstantlyTurn(_agent.destination);
        _agent.nextPosition = transform.position;
        transform.rotation = _agent.transform.rotation;
    }
    
    private void InstantlyTurn(Vector3 destination) {
        
        if ((destination - transform.position).magnitude < 0.1f) 
            return; 
     
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * _rotationSpeed);
    }
}
