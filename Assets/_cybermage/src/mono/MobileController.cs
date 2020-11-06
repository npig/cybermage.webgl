using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MobileController : MonoBehaviour
{
    internal NavMeshAgent _agent;
    internal Mobile _mobileData;
    internal Animator _animator;
    internal const float _rotationSpeed = 10f;
    internal Mobile _target;
    internal bool _isLocked;

    #region Lifecycle

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
            _animator.SetFloat("Velocity", _agent.velocity.magnitude);
        }
        else
        {
            _animator.SetFloat("Velocity", 0);
        }

        _agent.nextPosition = transform.position;
        TurnAgent(_agent.destination);
    }
    
    #endregion
    
    private void TurnAgent(Vector3 destination) 
    {
        //Todo: refactor
        if ((destination - transform.position).magnitude < 0.1f) 
            return; 
     
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * _rotationSpeed);
    }
    
    public Mobile GetMobile()
    {
        return _mobileData;
    }
    
    public void SetMobileData(Mobile mobileData)
    {
        _mobileData = mobileData;
    }
    
    public Mobile GetTarget()
    {
        return _target;
    }

    public void ClearTarget()
    {
        _target = null;
    }

    internal virtual void Attack()
    {
        
    }

    internal async UniTaskVoid Lock(int delayTime, int lockTime, Action unlockAction)
    {
        _isLocked = true;
        if (delayTime > 0)
            await UniTask.Delay(delayTime);
        
        await UniTask.Delay(lockTime);
        unlockAction?.Invoke();
        _isLocked = false;
    }

    internal bool HasReachedDestination()
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

    #region Animation Events
    public void Hit()
    {
    }
    public void Shoot()
    {
    }
    public void FootR()
    {
    }
    public void FootL()
    {
    }
    public void Land()
    {
    }
    #endregion

}
