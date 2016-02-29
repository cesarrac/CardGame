using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    public bool isHorizontal, isVertical, canTakeAllTypes;

    public CardType[] dropZoneTypes = new CardType[2];

    public void OnDrop(PointerEventData eventData)
    {
        // Check if dragged card is of the type allowed by this drop zone (ONLY IF NOT SET TO ALL)
        if (!canTakeAllTypes)
        {
            if (eventData.pointerDrag.GetComponent<Card_Handler>() != null)
            {
                int cardID = eventData.pointerDrag.GetComponent<Card_Handler>().ID;

                // If not equal to drop zone type, return!
                if (dropZoneTypes.Length > 0)
                {
                    for (int i = 0; i < dropZoneTypes.Length; i++)
                    {
                        if (Deck_Manager.Instance.GetCard(cardID).CardType == dropZoneTypes[i])
                            break;
                    }
                }
            }
        }


        // The object that is being dragged...
        if (eventData.pointerDrag.GetComponent<Draggable>() != null)
        {
            eventData.pointerDrag.GetComponent<Draggable>().playerHand = this.transform;
        }

        if (eventData.pointerDrag.GetComponent<Card_Handler>() != null)
        {
            eventData.pointerDrag.GetComponent<Card_Handler>().DropAction();
        }
    }
}
