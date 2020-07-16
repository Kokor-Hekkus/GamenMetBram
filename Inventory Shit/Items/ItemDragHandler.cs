using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectMarc
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected ItemSlotUI itemSlotUI = null;
        [SerializeField] protected HotBarItemEvent onMouseStartHover = null;
        [SerializeField] protected VoidEvent onMouseEndHover = null;

        private CanvasGroup canvasGroup = null;
        private Transform originalParent = null;
        private bool isHovering = false;

        public ItemSlotUI ItemSlotUI => itemSlotUI;

        private void Start() => canvasGroup = GetComponent<CanvasGroup>();

        private void OnDisable() //when disabling an item
        {
            if (isHovering)
            {
                onMouseEndHover.Raise();
                isHovering = false;
            }
        }

        public virtual void OnPointerDown(PointerEventData eventData) //clicking and start dragging
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                onMouseEndHover.Raise();
                originalParent = transform.parent;
                transform.SetParent(transform.parent.parent);
                canvasGroup.blocksRaycasts = false;
            }
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                transform.position = Input.mousePosition;
            }
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                transform.SetParent(originalParent);
                transform.localPosition = Vector3.zero;
                canvasGroup.blocksRaycasts = true;
            }
        }

        public void OnPointerEnter(PointerEventData eventData) //when mouse enters the item
        {
            onMouseStartHover.Raise(ItemSlotUI.SlotItem); //takes in the item
            isHovering = true;
        }
        public void OnPointerExit(PointerEventData eventData) //when mouse leaves the item
        {
            onMouseEndHover.Raise();
            isHovering = false;
        }
    }
}