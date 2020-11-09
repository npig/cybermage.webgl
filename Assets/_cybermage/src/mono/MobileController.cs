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

    private Vector2 _smoothDeltaPosition = Vector2.zero;
    private Vector2 _velocity = Vector2.zero;
    
    public virtual void Update() 
    {
        if (_agent == null) 
            return;

        Vector3 worldDeltaPosition = _agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot (transform.right, worldDeltaPosition);
        float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2 (dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
        _smoothDeltaPosition = Vector2.Lerp (_smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            _velocity = _smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = _velocity.magnitude > 0.1f && _agent.remainingDistance > 0.1f;

        // Update animation parameters
        _animator.SetBool("Moving", shouldMove);
        _animator.SetFloat ("VelocityX", _velocity.x);
        _animator.SetFloat ("VelocityY", _velocity.y);
        
        // Pull character towards agent
        transform.position = _agent.nextPosition - 0.9f * worldDeltaPosition;
        
        TurnAgent(_agent.steeringTarget);
    }
    #endregion

    private void OnAnimatorMove()
    {
        float speed = (_animator.deltaPosition / Time.deltaTime).magnitude;
        _agent.speed = Mathf.Clamp(speed, 1f, 4f);
    }

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
    
    internal async UniTaskVoid Lock(int delayTime, int lockTime, Action unlockAction)
    {
        _isLocked = true;
        if (delayTime > 0)
            await UniTask.Delay(delayTime *  60);
        
        await UniTask.Delay(lockTime * 60);
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
    public virtual void Shoot()
    {
        Debug.Log("ATTACK!@#!#");
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
