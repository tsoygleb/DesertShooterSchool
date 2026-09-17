using DS.Entities.Enemies.Behaviours;
using DS.Interfaces;
using DS.Player;
using UnityEngine;

namespace DS.Entities.Enemies
{
    public class Enemy : MonoBehaviour, IIntereactable
    {
        [SerializeField] private EnemyData _targetData = null;
        [Space(6)]
        [SerializeField] PlayerBase _target = null;

        private EnemyBehaviour[] _targetBehaviours = new EnemyBehaviour[0];
    
        public EnemyHealth HealthComponent { get; private set; }

        public PlayerBase Target { get { return _target; } private set { } }
        public EnemyData TargetData { get { return _targetData; } private set { } }

        private void Start()
        {
            _target = FindAnyObjectByType<PlayerBase>();

            HealthComponent = new EnemyHealth(this);

            _targetBehaviours = _targetData.GetBehaviours();

            for (int i = 0; i < _targetBehaviours.Length; i++)
            {
                _targetBehaviours[i].Initialize(this);
            }
        }

        private void Update()
        {
            if (_targetBehaviours.Length == 0) return;

            for (int i = 0; i < _targetBehaviours.Length; i++)
            {
                _targetBehaviours[i].Update();
            }
        }

        public virtual void Interact()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(float amount)
        {
            HealthComponent.TakeDamage(amount);
        }
    }   
}
