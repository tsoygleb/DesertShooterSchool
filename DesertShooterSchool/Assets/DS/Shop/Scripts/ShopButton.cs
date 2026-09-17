using UnityEngine;
using UnityEngine.UI;

namespace DS.Shop
{
    [RequireComponent(typeof(Button))]
    public class ShopButton : MonoBehaviour
    {
        [SerializeField] private GameObject _targetPanel = null;

        private void Start()
        {
            Button b = GetComponent<Button>();
            b.onClick.AddListener(delegate { _targetPanel.SetActive(!_targetPanel.activeSelf); });
        }
    }   
}
