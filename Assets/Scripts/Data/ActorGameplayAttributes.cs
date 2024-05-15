using System;
using ScriptableObjects.Data.BaseData;

namespace Data
{
    [Serializable]
    public class ActorGameplayAttributes
    {
        public float CurrentHealth;
        public float CurrentArmor;
        
        public ActorGameplayAttributes(BaseDamageableActorAttributesSO damageableActorAttributesSO)
        {
            CurrentHealth = damageableActorAttributesSO.Health;
            CurrentArmor = damageableActorAttributesSO.Armor;
        }
        
    }
}