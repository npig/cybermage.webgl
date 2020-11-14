using UnityEngine;
using System.Collections.Generic;
using Cybermage;
using Cybermage.Entities;
using Cybermage.Events;
using UnityEngine.AI;

public static class EntityFactory
{
    private static Entity PlayerType;
    private static Entity ZombieType;
    private static Entity ZombieWizardType;

    public static List<Mobile> MobileCollection = new List<Mobile>();
    public static Mobile Player;

    public static void Awake()
    {
        PlayerType = new Entity(null, 
            new EntityData(EntityType.PLAYER,
                Resources.Load<MobileController>(CM_Resources.prefabs.entities.Cybermage.Path),
                10,
                50,
                10,
                2,
                4,
                10));
        
        ZombieType = new Entity(null, 
            new EntityData(EntityType.MOB,
                Resources.Load<MobileController>(CM_Resources.prefabs.entities.Zombie.Path),
                10,
                10,
                8,
                2,
                2,
                5));
    }

    public static Mobile SpawnPlayer(Vector3 spawnPosition)
    {
        Mobile playerMobile = PlayerType.SpawnMobile(spawnPosition);
        GlobalsConfig.SetPlayer(playerMobile);
        Player = playerMobile;
        return playerMobile;
    }
    
    public static Mobile SpawnZombie(Vector3 spawnPosition)
    {
        Mobile zombieMobile = ZombieType.SpawnMobile(spawnPosition);
        MobileCollection.Add(zombieMobile);
        return zombieMobile;
    }
    
    public static Mobile SpawnZombieWizard(Vector3 spawnPosition)
    {
        Mobile zombieWizardMobile = ZombieWizardType.SpawnMobile(spawnPosition);
        MobileCollection.Add(zombieWizardMobile);
        return zombieWizardMobile;
    }
}

public class Entity
{
    private EntityData _entityData;
    private Entity _parent;
    
    public Entity(Entity parent, EntityData entityData = null)
    {
        _entityData = entityData;
        _parent = null;

        if (parent == null) 
            return;
        
        _parent = parent;

        if (entityData == null)
        {
            _entityData = parent.GetData();
        }
        
    }

    public Mobile SpawnMobile(Vector3 spawnPosition)
    {
        MobileController mc = MonoBehaviour.Instantiate(_entityData.EntityPrefab);
        NavMesh.SamplePosition(spawnPosition, out NavMeshHit hit, Mathf.Infinity, NavMesh.AllAreas);
        mc.GetComponent<NavMeshAgent>().Warp(hit.position);
        mc.transform.position = hit.position;
        Mobile mobile = new Mobile(this, mc);
        mc.SetMobileData(mobile);

        
        return mobile;
    }

    public EntityData GetData()
    {
        return _entityData;
    }
}


public class Mobile
{
    private Entity _entityType;
    private EntityData _mobileData;
    private MobileController _mobileController;
    public bool _isDead { get; private set; }

    public Mobile(Entity entityType, MobileController mobileController)
    {
        _mobileData = entityType.GetData();
        _entityType = entityType;
        _mobileController = mobileController;
    }

    public void TakeDamage(int dmg)
    {
        _mobileData.Health -= dmg;

        if (_mobileData.Health <= 0)
        {
            _isDead = true;
            EventManager.Instance.Raise(new DeathEvent(this));
        }
    }
    
    public void Heal(int healAmount)
    {
        _mobileData.Health += healAmount;
        _mobileData.Health = Mathf.Clamp(_mobileData.Health, 0, 50);
    }

    
    public Mobile GetTarget() => _mobileController.GetTarget();
    public EntityData GetData() => _mobileData;
    public MobileController GetController() => _mobileController;
    public Vector3 GetPosition() => _mobileController.transform.position;
    public Transform GetTransform() => _mobileController.transform;

}

public class DeathEvent : IEvent
{
    public Mobile MobileData { get; private set; }

    public DeathEvent(Mobile mobile)
    {
        MobileData = mobile;
    }
}





