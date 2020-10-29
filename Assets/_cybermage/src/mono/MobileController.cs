using System;
using UnityEngine;
using UnityEngine.AI;

public class MobileController : MonoBehaviour
{
    internal Mobile _mobileData;
    internal Animator _animator;
    internal NavMeshAgent _agent;
    internal const float _rotationSpeed = 10f;
    
    public virtual void Awake() 
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updatePosition = false;
    }
    
    public virtual void Update() 
    {
        if (_agent == null) 
            return;
        
        if(_agent.velocity.sqrMagnitude > 0)
        {
            _animator.SetBool("Moving", true);
            _animator.SetFloat("Velocity Z", _agent.velocity.magnitude);
        }
        else
        {
            _animator.SetFloat("Velocity Z", 0);
        }
        
        if(!_agent.hasPath)
            return;
        
        _agent.nextPosition = transform.position;
        TurnAgent(_agent.destination);
    }

    public Mobile GetMobile()
    {
        return _mobileData;
    }
    
    public void SetMobileData(Mobile mobileData)
    {
        _mobileData = mobileData;
    }
    
    private void TurnAgent(Vector3 destination) {
        
        if ((destination - transform.position).magnitude < 0.1f) 
            return; 
     
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * _rotationSpeed);
    }

    private bool HasReachedDestination()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    public void FootL()
    {
        
    }

    public void FootR()
    {
        
    }
}
