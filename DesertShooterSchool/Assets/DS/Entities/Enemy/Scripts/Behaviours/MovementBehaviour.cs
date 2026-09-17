using UnityEngine;

namespace DS.Entities.Enemies.Behaviours
{
     [CreateAssetMenu(fileName = "New Movement", menuName = "DS/Entities/Behaviours/New Movement")]
    public class MovementBehaviour : EnemyBehaviour
    {
        private Enemy _controller = null;

        public override void Initialize(Enemy controller)
        {
            _controller = controller;
        }

        public override void Update()
        {
            if (_controller.Target == null) return;

            Vector2 a = _controller.transform.position;
            Vector2 b = _controller.Target.transform.position;
            float speed = _controller.TargetData.MovementSpeed * Time.deltaTime;

            _controller.transform.position = Vector2.MoveTowards(a, b, speed);
        }
    }
}
