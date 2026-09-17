using System.Collections;
using UnityEngine;

namespace DS.Entities.Enemies.Behaviours
{
    [CreateAssetMenu(fileName = "New Meelea Attack", menuName = "DS/Entities/Behaviours/New Meelea Attack")]
    public class MeleaAttackBehaviour : EnemyBehaviour
    {
        private Enemy _controller = null;

        private float _timerDefaultTime = 0;
        private float _timerCurrentTime = 0f;

        public override void Initialize(Enemy controller)
        {
            _controller = controller;

            _timerDefaultTime = _controller.TargetData.AttackCooldown;
            _timerCurrentTime = _timerDefaultTime;
        }

        public override void Update()
        {
            Vector2 currentPosition = _controller.transform.position;
            Vector2 targetPosition = _controller.Target.transform.position;

            if (Vector2.Distance(currentPosition, targetPosition) < _controller.TargetData.AttackRange)
            {
                if (_timerCurrentTime <= 0)
                {
                    _timerCurrentTime = _timerDefaultTime;

                    _controller.Target.TakeDamage(_controller.TargetData.Damage); 
                }

                _timerCurrentTime -= 1 * Time.deltaTime;
            }
        }
    }
}
