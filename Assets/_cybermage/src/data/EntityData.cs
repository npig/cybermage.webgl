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
        public float AlertRange { get; private set; }
        public float AttackRange { get; private set; }
        public int AttackDamage { get; private set; }
        public float Cooldown { get; private set; }
        public float Speed { get; set; }
        public int Health { get; set; }

        
        public EntityData(
            EntityType entityType,
            MobileController entityPrefab,
            float speed,
            int health,
            float alertRange,
            float cooldown,
            float attackRange,
            int attackDamage)
        {
            EntityType = entityType;
            EntityPrefab = entityPrefab;
            Speed = speed;
            Health = health;
            AlertRange = alertRange;
            Cooldown = cooldown;
            AttackRange = attackRange;
            AttackDamage = attackDamage;
        }
    }
}