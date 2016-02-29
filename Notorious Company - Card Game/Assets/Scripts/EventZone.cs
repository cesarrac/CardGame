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
        if (eventData.pointerDrag.GetComponent<Card_Handler>() != null)
        {
            Card card = Deck_Manager.Instance.GetCard(eventData.pointerDrag.GetComponent<Card_Handler>().ID);

            if (CheckCardTypes(card) != true || CheckEventTypes(card) != true)
                return;
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

    bool CheckCardTypes(Card card)
    {
        // If not equal to drop zone type, return!
        if (dropZoneTypes.Length > 0)
        {
            for (int i = 0; i < dropZoneTypes.Length; i++)
            {
                if (card.CardType == dropZoneTypes[i])
                    return true;
            }

            
        }

        return false;
    }

    bool CheckEventTypes(Card card)
    {

        for (int i = 0; i < card.WorldEventTypes.Length; i++)
        {
            if (card.WorldEventTypes[i] == eventType)
                return true;
        }

        // if no type was equal to this one, return
        return false;
      
    }
}
