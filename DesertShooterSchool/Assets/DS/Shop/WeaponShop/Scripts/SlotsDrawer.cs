using System.Collections.Generic;
using DS.Items;
using DS.Player;
using UnityEngine;

namespace DS.Shop.WeaponShop
{
    public class SlotsDrawer : MonoBehaviour
    {
        [SerializeField] private Transform _slotContainer = null;
        [SerializeField] private WeaponSlot _slotPrefab = null;
        [Space(6)]
        [SerializeField] private Weapon[] _weapons = null;
        [Header("Others:")]
        [SerializeField] private PlayerController _player = null;

        private List<WeaponSlot> _instSlots = new List<WeaponSlot>();

        private void Start()
        {
            Draw();
        }

        public void Clear()
        {
            if (_instSlots.Count == 0) return;

            for (int i = 0; i < _instSlots.Count; i++)
            {
                Destroy(_instSlots[i].gameObject);
            }

            _instSlots.Clear();
        }

        public void Draw()
        {
            if (_weapons.Length == 0) return;

            for (int i = 0; i < _weapons.Length; i++)
            {
                WeaponSlot inst = Instantiate(_slotPrefab, _slotContainer, false);
                inst.transform.localScale = new Vector3(1, 1, 1);
                inst.Initialize(_weapons[i], _player);
            }
        }
    }   
}
