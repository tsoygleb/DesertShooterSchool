using UnityEngine;
using UnityEngine.UI;

namespace DS.GUI
{
    public class LinearBar : MonoBehaviour
    {
        [SerializeField] private float _maxAmount = 100;
        [SerializeField] private float _currentAmount = 100;
        [Space(6)]
        [SerializeField] private Image _targetImage = null;

        public void SetAmount(float amount)
        {
            if (amount < 0) return;

            _currentAmount = amount;

            float fill = _currentAmount/_maxAmount;
            _targetImage.fillAmount = fill;
        }
    }   
}
