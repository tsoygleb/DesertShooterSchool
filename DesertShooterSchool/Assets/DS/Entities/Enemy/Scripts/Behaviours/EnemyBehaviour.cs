using UnityEngine;

namespace DS.Entities.Enemies.Behaviours
{
    public abstract class EnemyBehaviour : ScriptableObject
    {
        public abstract void Initialize(Enemy controller);
        public abstract void Update();
    }   
}
