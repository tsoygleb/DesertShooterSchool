using System;
using DS.GUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DS.Player
{
    public class PlayerUIDrawer : MonoBehaviour
    {
        [SerializeField] private LinearBar _healthBar = null;
        [SerializeField] private TextMeshProUGUI _moneyText = null;
        [Space(6)]
        [SerializeField] private Image _weaponIcon = null;
        [SerializeField] private TextMeshProUGUI _weaponDamageText = null;
        [Space(6)]
        [SerializeField] private PlayerController _targetController = null;

        public static Action OnDraw;

        private void Start()
        {
            OnDraw += Draw;
        }

        public void Draw()
        {
            PlayerData data = _targetController.TargetData;

            _healthBar.SetAmount(data.BaseHealth);
            _moneyText.text = data.MoneyCount.ToString();

            _weaponIcon.sprite = data.CurrentWeapon.ItemSprite;
            _weaponDamageText.text = data.CurrentWeapon.Damage.ToString();
        }
    }   
}
