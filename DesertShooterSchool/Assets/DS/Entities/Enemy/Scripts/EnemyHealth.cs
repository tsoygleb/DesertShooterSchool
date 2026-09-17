using UnityEngine;

namespace DS.Entities.Enemies
{
    public class EnemyHealth
    {
        public EnemyHealth(Enemy controller)
        {
            _controller = controller;

            _currentHealthCount = _controller.TargetData.HealthCount;
        }

        private Enemy _controller = null;

        private float _currentHealthCount = 0f;

        public void TakeDamage(float amount)
        {
            _currentHealthCount -= amount;

            if (_currentHealthCount <= 0)
            {
                if (_controller.TargetData.DropItems.Length > 0)
                {
                    for (int i = 0; i < _controller.TargetData.DropItems.Length; i++)
                    {
                        MonoBehaviour.Instantiate(_controller.TargetData.DropItems[i].TargetPrefab, _controller.transform.position, Quaternion.identity);
                    }
                }

                MonoBehaviour.Destroy(_controller.gameObject);
            }
        }
    }   
}
