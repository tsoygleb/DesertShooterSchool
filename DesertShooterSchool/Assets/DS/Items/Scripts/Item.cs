using UnityEngine;

namespace DS.Items
{
    public abstract class Item : ScriptableObject
    {
        [Header("Default Properties:")]
        [SerializeField] private ItemObject _targetPrefab = null;
        [SerializeField] private Sprite _itemSprite = null;
        [Space(6)]
        [SerializeField, TextArea(5, 20)] private string _description = "";
        [SerializeField] private int _cost = 0;

        public ItemObject TargetPrefab { get { return _targetPrefab; } private set { } }
        public Sprite ItemSprite { get { return _itemSprite; } private set { } }

        public string Description { get { return _description; } private set { } }
        public int Cost { get { return _cost; } private set { } }

        public abstract void Use(ItemObject targetObject);
    }   
}
