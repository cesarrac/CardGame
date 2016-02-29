using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform playerHand;
    public Transform placeHolderParent;

    GameObject placeHolder;

    public void OnBeginDrag(PointerEventData eventData)
    {
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement layout = placeHolder.AddComponent<LayoutElement>();
        layout.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
        layout.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
        layout.flexibleHeight = 0;
        layout.flexibleWidth = 0;

        placeHolder.transform.SetSiblingIndex(transform.GetSiblingIndex());

        playerHand = this.transform.parent;
        placeHolderParent = playerHand;

        // parent to the canvas
        this.transform.SetParent(this.transform.root);

        // turn off block raycasts
        if (GetComponent<CanvasGroup>() != null)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        int newSiblingIndex = placeHolderParent.childCount;

        for (int i = 0; i < playerHand.childCount; i++)
        {
            if (placeHolderParent.gameObject.GetComponent<DropZone>() != null)
            {
                if (placeHolderParent.gameObject.GetComponent<DropZone>().isHorizontal)
                {
                    if (transform.position.x < playerHand.GetChild(i).position.x)
                    {
                        newSiblingIndex = i;

                        if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                            newSiblingIndex--;

                        break;
                    }
                }
                else
                {
                    if (transform.position.y > playerHand.GetChild(i).position.y)
                    {
                        newSiblingIndex = i;

                        if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                            newSiblingIndex--;

                        break;
                    }
                }
            }
    
        }

        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GetComponent<CanvasGroup>() != null)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        this.transform.SetParent(playerHand);

        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());

        Destroy(placeHolder);
    }

}
