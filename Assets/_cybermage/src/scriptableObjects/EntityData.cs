using UnityEngine;

namespace Cybermage.Entities
{
    public enum EntityType
    {
        PLAYER,
        MOB
    }
        
    public class EntityData
    {
        public EntityType EntityType { get; private set; }
        public MobileController EntityPrefab { get; private set; }
        public float Range { get; private set; }
        public bool IsEnemy { get; private set; }
        public float Speed { get; set; }
        public int Health { get; set; }


        public EntityData(
            EntityType entityType,
            MobileController entityPrefab,
            float speed,
            int health,
            float range,
            bool isEnemy)
        {
            EntityType = entityType;
            EntityPrefab = entityPrefab;
            Speed = speed;
            Health = health;
            Range = range;
            IsEnemy = isEnemy;
        }
    }
}