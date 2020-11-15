using System;
using System.Threading;
using Cybermage.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MobileController : MonoBehaviour
{
    internal NavMeshAgent _agent;
    internal Mobile _mobileData;
    internal Animator _animator;
    internal Mobile _target;
    internal bool _isDead;
    internal bool _isLocked;
    internal bool _isAgro;
    
    private const float _rotationSpeed = 10f;
    private Vector2 _smoothDeltaPosition = Vector2.zero;
    private Vector2 _velocity = Vector2.zero;

    
    #region Lifecycle
    public virtual void Awake() 
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updatePosition = false;
        EventManager.Instance.AddListener<DeathEvent>(MobileDeath);
    }

    public virtual void Update() 
    {
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

    //We're using root motion to smooth out mobile speed, this will help prevent floating animation cycles
    private void OnAnimatorMove()
    {
        float speed = (_animator.deltaPosition / Time.deltaTime).magnitude;
        _agent.speed = Mathf.Clamp(speed, 1f, 4f);
    }

    //Manual rotation control of navmesh agent
    private void TurnAgent(Vector3 destination) 
    {
        //Todo: refactor
        if ((destination - transform.position).magnitude < 0.1f) 
            return; 
     
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * _rotationSpeed);
    }

    //Await UniTask to freeze mobile during animation or actions
    internal async UniTaskVoid Lock(int lockTime, Action unlockAction)
    {
        _isLocked = true;

        await UniTask.Delay(
            lockTime * 60, 
            DelayType.DeltaTime, 
            PlayerLoopTiming.Update, 
            this.GetCancellationTokenOnDestroy());
        
        unlockAction?.Invoke();
        _isLocked = false;
    }
    
    //Mobile Death Event
    private void MobileDeath(DeathEvent e)
    {
        if (e.Mobile != _mobileData)
            return;
        
        _isDead = true;
        _agent.enabled = false;
        _animator.SetTrigger("Death");
    }
    
    // Data Getters and Setters
    public void SetMobileData(Mobile mobileData)
    {
        _mobileData = mobileData;
    }

    public Mobile GetMobile()
    {
        return _mobileData;
    }
    // ^    
    public void TakeDamage(int i)
    {
        _mobileData.TakeDamage(i);
        _animator.SetTrigger("GetHit");
    }

    public Mobile GetTarget()
    {
        return _target;
    }

    public void ClearTarget()
    {
        _target = null;
    }

    #region Animation Events
    public void Hit() { }

    public virtual void Shoot()
    {
        _target?.TakeDamage(_mobileData.GetData().AttackDamage);
    }
    public void FootR() { }
    public void FootL() { }
    public void Land() { }
    #endregion

}
