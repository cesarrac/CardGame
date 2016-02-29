using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Card_Handler : MonoBehaviour {

    int id;
    public int ID { get { return id; } }
    Card myCard;

    public Text cardTitle, cardName, cardDescription, cardType, worldEventTypeOne, worldEventTypeTwo;

    Func<int, bool> checkCost_func;

    public void InitCard(int ID, Card card)
    {
        id = ID;
        myCard = card;

        cardTitle.text = myCard.CardTitle;
        cardDescription.text = myCard.CardDescription;
        cardType.text = myCard.CardType.ToString();

        worldEventTypeOne.text = myCard.WorldEventTypes[0].ToString();
        if (myCard.WorldEventTypes.Length > 1)
        {
            worldEventTypeTwo.text = myCard.WorldEventTypes[1].ToString();
        }
    }

    public void RegisterDropActionCB(Func<int, bool> cb)
    {
        checkCost_func = cb;
    }

    public void DropAction()
    {
        if (checkCost_func != null)
        {
            if (CheckCostAtDrop() == false)
            {
                transform.SetParent(Deck_Manager.Instance.playerDeck);
            }
        }
        else
            return;
    }


    public bool CheckCostAtDrop()
    {
        return checkCost_func(-myCard.AgentCost);
    }
}
