using DS.Items;
using DS.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DS.Shop.WeaponShop
{
    public class WeaponSlot : MonoBehaviour
    {
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private TextMeshProUGUI _descriptionText = null;
        [SerializeField] private TextMeshProUGUI _damageText = null;
        [SerializeField] private TextMeshProUGUI _costText = null;
        [SerializeField] private Button _buyButton = null;

        public void Initialize(Weapon item, PlayerController player)
        {
            if (item == null) return;

            _iconImage.sprite = item.ItemSprite;
            _descriptionText.text = item.Description;
            _damageText.text = item.Damage.ToString();
            _costText.text = item.Cost.ToString();

            _buyButton.onClick.AddListener
            (
                delegate
                {
                    if (player.TargetData.MoneyCount >= item.Cost)
                    {
                        player.TargetData.MoneyCount -= item.Cost;
                        player.ChangeWeapon(item);
                    }
                }
            );
        }
    }   
}
