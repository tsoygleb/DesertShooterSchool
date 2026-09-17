using System.Collections.Generic;
using DS.Entities.Enemies.Behaviours;
using DS.Items;
using UnityEngine;

namespace DS.Entities.Enemies
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "DS/Entities/New Enemy")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private float _healthCount = 10f;
        [SerializeField] private float _movementSpeed = 4f;
        [Space(6)]
        [SerializeField] private float _attackRange = 0.2f;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _damage = 4f;
        [Space(6)]
        [SerializeField] private List<EnemyBehaviour> _behaviours = new List<EnemyBehaviour>();
        [Space(6)]
        [SerializeField] private Item[] _dropItems = new Item[0];

        public float HealthCount { get { return _healthCount; } private set { } }
        public float MovementSpeed { get { return _movementSpeed; } private set { } }

        public float AttackRange { get { return _attackRange; } private set { } }
        public float AttackCooldown { get { return _attackCooldown; } private set { } }
        public float Damage { get { return _damage; } private set { } }

        public Item[] DropItems { get { return _dropItems; } private set { } }

        public EnemyBehaviour[] GetBehaviours()
        {
            EnemyBehaviour[] a = new EnemyBehaviour[_behaviours.Count];

            for (int i = 0; i < _behaviours.Count; i++)
            {
                a[i] = Instantiate(_behaviours[i]);
            }

            return a;
        }
    }   
}
