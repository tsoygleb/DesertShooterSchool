using DS.Entities.Enemies;
using UnityEngine;

namespace DS.Wave
{
    [CreateAssetMenu(fileName = "New Wave Definition", menuName = "DS/Waves/New Wave Definition")]
    public class WaveDefinition : ScriptableObject
    {
        [SerializeField] private Enemy[] _enemies = new Enemy[0];
        [SerializeField] private int _enemyPerTime = 4;
        [SerializeField] private float _delayTime = 1f;

        public Enemy[] Enemies { get { return _enemies; } private set { } }
        public int EnemyPerTime { get { return _enemyPerTime; } private set { } }
        public float DelayTime { get { return _delayTime; } private set { } }
    }    
}
