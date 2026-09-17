using DS.Entities.Enemies;
using DS.Interfaces;
using DS.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DS.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerCrosshair _targetCrosshair = null;
        [Space(6)]
        [SerializeField] private Weapon _defaultWeapon = null;

        private PlayerData _targetData = new PlayerData();

        public PlayerData TargetData { get { return _targetData; } private set { } }

        private void Start()
        {
            ChangeWeapon(_defaultWeapon);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                if (_targetCrosshair.TryGetInteractObject(out IIntereactable intereactable) == true)
                {
                    if (TryAttackEnemy(intereactable) == false)
                    {
                        intereactable.Interact();
                    }
                }
            }
        }

        private bool TryAttackEnemy(IIntereactable intereactable)
        {
            if (intereactable == null) return false;
            if (intereactable is not Enemy) return false;

            Enemy target = intereactable as Enemy;

            _targetData.CurrentWeapon.Attack(target);

            return true;
        }

        public void ChangeWeapon(Weapon weapon)
        {
            if (weapon == null) return;

            _targetData.CurrentWeapon = weapon;

            PlayerUIDrawer.OnDraw?.Invoke();
        }
    }    
}