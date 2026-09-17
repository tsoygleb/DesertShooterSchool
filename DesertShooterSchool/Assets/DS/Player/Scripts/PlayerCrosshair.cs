using DS.Interfaces;
using UnityEngine;

namespace DS.Player
{
    public class PlayerCrosshair : MonoBehaviour
    {
        private Vector2 _mousePosition = Vector2.zero;

        private void Start()
        {
            Cursor.visible = false;
        }

        private void Update()
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            MoveToMouse();
        }

        private void MoveToMouse()
        {
            Vector2 mousePosition = _mousePosition;
            transform.position = mousePosition;
        }

        public bool TryGetInteractObject(out IIntereactable intereactable)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(_mousePosition, 0.1f);

            if (collider2Ds.Length == 0)
            {
                intereactable = null;
                return false;
            }

            for (int i = 0; i < collider2Ds.Length; i++)
            {
                if (collider2Ds[i].TryGetComponent(out IIntereactable component) == true)
                {
                    intereactable = component;
                    return true;   
                }
            }

            intereactable = null;
            return false;
        }
    }
}


