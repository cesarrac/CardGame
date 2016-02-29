using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck_Manager : MonoBehaviour {

    public static Deck_Manager Instance { get; protected set; }

    Dictionary<int, Card> cards_Map;
    List<int> currentDeck;
    List<int> discardPile;

    int minHandSize = 3;

    public GameObject cardPrefab;

    public Transform playerDeck;

    void OnEnable()
    {
        Instance = this;
    }

    void Awake()
    {

        InitializeDeck();
    }

	void InitializeDeck()
    {
        // For now create 10 cards
        cards_Map = new Dictionary<int, Card>
        {
            {0, new Card("Miguel Santana", CardType.AGENT, WorldEventType.POLITICS, WorldEventType.MEDIA) },
            {1, new Card("Juana Malanga", CardType.AGENT, WorldEventType.MILITARY, WorldEventType.MEDIA) },
            {2, new Card("Place a Bomb.", CardType.ACTION, WorldEventType.POLITICS, WorldEventType.MILITARY) },
            {3, new Card("Bribe Statesman.", CardType.ACTION, WorldEventType.POLITICS) },
            {4, new Card("Stolen explosives", CardType.ITEM, WorldEventType.MILITARY) },
            {5, new Card("Official Papers", CardType.ITEM, WorldEventType.POLITICS) },
            {6, new Card("Black Mask", CardType.ITEM, WorldEventType.MEDIA) },
            {7, new Card("Radio Tower Takeover", CardType.ACTION, WorldEventType.MEDIA) },
            {8, new Card("Horacio Mendez", CardType.AGENT, WorldEventType.MEDIA, WorldEventType.CORPORATIONS) },
            {9, new Card("Bugout!", CardType.ACTION, WorldEventType.MILITARY) }
        };

        currentDeck = new List<int>();

        for (int i = 0; i < cards_Map.Count; i++)
        {
            currentDeck.Add(i);
        }

        discardPile = new List<int>();
    }

    public void Deal()
    {
        // If the deck doesn't have at least min hand size, return!
        // TODO: Figure out if this is a game over or what
        if (currentDeck.Count < minHandSize)
        {
            Debug.Log("DECK IS OUT OF CARDS!");
            return;
        }
          

        // Get 3 id # from the current Deck list
        for (int i = 0; i < 3; i++)
        {
            int id = GetID();
            if (cards_Map.ContainsKey(id))
            {
                Card card = cards_Map[id];
                Debug.Log("Card " + (i + 1) + " is " + card.CardTitle + " and of type " + card.CardType);

                GameObject newCard = Instantiate(cardPrefab, Vector2.one, Quaternion.identity) as GameObject;
                newCard.transform.SetParent(playerDeck);
                newCard.GetComponent<Card_Handler>().InitCard(id, card);

                if (card.CardType == CardType.AGENT)
                {
                    newCard.GetComponent<Card_Handler>().RegisterDropActionCB(Company_Handler.Instance.AddAgent);
                }

                currentDeck.Remove(id);
            }

        }
    }

    int GetID()
    {
        return currentDeck[Random.Range(0, currentDeck.Count)];
    }

    public Card GetCard(int id)
    {
        if (cards_Map.ContainsKey(id))
        {
            return cards_Map[id];
        }
        else
            return null;

    }
}
