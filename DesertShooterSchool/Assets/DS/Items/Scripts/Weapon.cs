using DS.Entities.Enemies;
using UnityEngine;

namespace DS.Items
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "DS/Items/New Weapon")]
    public class Weapon : Item
    {
        [Header("Weapon Properties:")]
        [SerializeField] private float _damage = 1f;

        public float Damage { get { return _damage; } private set { } }

        public override void Use(ItemObject targetObject)
        {
            throw new System.NotImplementedException();
        }

        public void Attack(Enemy enemy)
        {
            if (enemy == null) return;

            enemy.TakeDamage(_damage);
        }
    }
}
