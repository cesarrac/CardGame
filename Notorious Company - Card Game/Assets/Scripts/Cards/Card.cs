using UnityEngine;
using System.Collections;

[System.Serializable]
public enum CardType
{
    AGENT,
    ACTION,
    ITEM,
    ALL
}

[System.Serializable]
public class Card  {

    string cardTitle;
    public string CardTitle { get { return cardTitle; } }

    string cardDescription;
    public string CardDescription { get { return cardDescription; } }

    CardType cardType;
    public CardType CardType { get { return cardType; } }

    int agentCost = 0;
    public int AgentCost
    {
        get { return agentCost; }
    }

    WorldEventType[] worldEventTypes;
    public WorldEventType[] WorldEventTypes { get { return worldEventTypes; } }

    public Card (string title, CardType cType, WorldEventType eventTypeOne, WorldEventType eventTypeTwo = WorldEventType.NONE, string desc = "This is a really awesome card!")
    {
        cardTitle = title;
        cardDescription = desc;
        cardType = cType;
        
        if (cType == CardType.AGENT)
        {
            agentCost = 1;
        }

        if (eventTypeTwo != WorldEventType.NONE)
        {
            worldEventTypes = new WorldEventType[]
            {
                eventTypeOne,
                eventTypeTwo
            };
        }
        else
        {
            worldEventTypes = new WorldEventType[]
            {
                eventTypeOne
            };
        }
 
    }
}
