using DS.Interfaces;
using UnityEngine;

namespace DS.Items
{
    public class ItemObject : MonoBehaviour, IIntereactable
    {
        [SerializeField] private Item _targetItem = null;
        [Space(6)]
        [SerializeField] private SpriteRenderer _targetGraphic = null;

        public Item TargetItem { get { return _targetItem; } private set { } }

        private void OnValidate()
        {
            if (_targetItem != null) Initialize(_targetItem);
        }

        public void Initialize(Item item)
        {
            _targetItem = item;
            _targetGraphic.sprite = _targetItem.ItemSprite;
        }

        public void Interact()
        {
            _targetItem.Use(this);
        }
    }   
}