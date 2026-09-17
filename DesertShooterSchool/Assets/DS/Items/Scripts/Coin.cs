using DS.Player;
using UnityEngine;

namespace DS.Items
{
    [CreateAssetMenu(fileName = "New Coin", menuName = "DS/Items/New Coin")]
    public class Coin : Item
    {
        [Header("Coin Properties:")]
        [SerializeField] private int _coinAmount = 1;

        public override void Use(ItemObject targetObject)
        {
            FindFirstObjectByType<PlayerController>().TargetData.MoneyCount += _coinAmount;
            PlayerUIDrawer.OnDraw?.Invoke();

            Destroy(targetObject.gameObject);
        }
    }   
}
