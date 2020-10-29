using UnityEngine;
using System.Collections.Generic;
using Cybermage.Entities;
using UnityEngine.AI;

public static class EntityFactory
{
    private static Entity PlayerType;
    private static Entity ZombieType;
    private static Entity ZombieWizardType;

    private static List<Mobile> MobileCollection = new List<Mobile>();

    public static void Awake()
    {
        PlayerType = new Entity(null, 
            new EntityData(EntityType.PLAYER,
                Resources.Load<MobileController>(CM_Resources.prefabs.entities.Cybermage.Path),
                10,
                50,
                3,
                false));
        
        ZombieType = new Entity(null, 
            new EntityData(EntityType.MOB,
                Resources.Load<MobileController>(CM_Resources.prefabs.entities.Zombie.Path),
                10,
                10,
                1,
                true));
    }

    public static Mobile SpawnPlayer(Vector3 spawnPosition)
    {
        Mobile playerMobile = PlayerType.SpawnMobile(spawnPosition);
        MobileCollection.Add(playerMobile);
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
    private EntityData _mobileData;
    private Entity _entity;
    private MobileController _mobileController;

    public Mobile(Entity entity, MobileController mobileController)
    {
        _mobileData = entity.GetData();
        _entity = entity;
        _mobileController = mobileController;
    }

    public EntityData GetData() => _mobileData;
    public MobileController GetController() => _mobileController;
    public Vector3 GetPosition() => _mobileController.transform.position;
}





