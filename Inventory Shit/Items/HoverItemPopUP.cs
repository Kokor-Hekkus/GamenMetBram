using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectMarc
{
    public class HoverItemPopUP : MonoBehaviour
    {
        [SerializeField] private GameObject popupCanvasObject = null;
        [SerializeField] private RectTransform popupObject = null;
        [SerializeField] private TextMeshProUGUI infoText = null;
        [SerializeField] private Vector3 offset = new Vector3(0f, 50f, 0f);
        [SerializeField] private float padding = 25f;

        private Canvas popupCanvas = null;

        private void Start() => popupCanvas = popupCanvasObject.GetComponent<Canvas>();

        private void Update() => FollowCursor();

        public void HideInfo() => popupCanvasObject.SetActive(false);

        private void FollowCursor()
        {
            if (!popupCanvasObject.activeSelf) { return; } //making sure the pop-up is active

            Vector3 newPos = Input.mousePosition + offset; //calc position
            newPos.z = 0f;

            //handle the padding
            float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + popupObject.rect.width * popupCanvas.scaleFactor / 2) - padding;
            if (rightEdgeToScreenEdgeDistance < 0)
            {
                newPos.x += rightEdgeToScreenEdgeDistance;
            }
            float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - popupObject.rect.width * popupCanvas.scaleFactor / 2) + padding;
            if (leftEdgeToScreenEdgeDistance > 0)
            {
                newPos.x += leftEdgeToScreenEdgeDistance;
            }
            float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + popupObject.rect.height * popupCanvas.scaleFactor) - padding;
            if (topEdgeToScreenEdgeDistance < 0)
            {
                newPos.y += topEdgeToScreenEdgeDistance;
            }
            popupObject.transform.position = newPos;
        }

        public void DisplayInfo(Item infoItem)
        {
            StringBuilder builder = new StringBuilder(); //create string builder

           // builder.Append("<size=35>").Append(infoItem.ColouredName).Append("</size>\n"); //get the custom display text
            builder.Append(infoItem.GetInfoDisplayText());

            infoText.text = builder.ToString(); //set the text to be displayed

            popupCanvasObject.SetActive(true); //activate the ui canvas object

            LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject); // fixe resize issues
        }
    }
}