using DS.GUI;
using UnityEngine;

namespace DS.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [Header("GUI:")]
        [SerializeField] private GameObject _losePanel = null;
        [Header("Others:")]
        [SerializeField] private PlayerController _controller = null;

        public void TakeDamage(float damage)
        {
            _controller.TargetData.BaseHealth -= damage;

            if (_controller.TargetData.BaseHealth <= 0)
            {
                _losePanel.SetActive(true);
            }

            PlayerUIDrawer.OnDraw?.Invoke();
        }
    }   
}
