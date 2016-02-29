using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class EventZone : MonoBehaviour, IDropHandler
{

    public bool isHorizontal, isVertical, canTakeAllTypes;

    public CardType[] dropZoneTypes = new CardType[2];

    public WorldEventType eventType;

    public void InitEventType(WorldEventType eType)
    {
        eventType = eType;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card card = Deck_Manager.Instance.GetCard(eventData.pointerDrag.GetComponent<Card_Handler>().ID);

        // Only allow one card to be place on here
        //if (transform.childCount > 1)
        //{
        //    return;
        //}


        // Check if dragged card is of the type allowed by this drop zone (ONLY IF NOT SET TO ALL)
        if (!canTakeAllTypes)
        {
            if (eventData.pointerDrag.GetComponent<Card_Handler>() != null)
            {
                // If not equal to drop zone type, return!
                if (dropZoneTypes.Length > 0)
                {
                    for (int i = 0; i < dropZoneTypes.Length; i++)
                    {
                        if (card.CardType == dropZoneTypes[i])
                            break;
                    }

                   // return;
                }
            }
        }

        // Check for Event Type
        if (eventData.pointerDrag.GetComponent<Card_Handler>() != null)
        {
            for (int i = 0; i < card.WorldEventTypes.Length; i++)
            {
                if (card.WorldEventTypes[i] == eventType)
                    break;
            }

            // if no type was equal to this one, return
            //return;
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
