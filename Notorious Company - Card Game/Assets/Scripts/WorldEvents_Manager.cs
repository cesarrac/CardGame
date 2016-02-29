using UnityEngine;
using System.Collections.Generic;

public class WorldEvents_Manager : MonoBehaviour {

    public static WorldEvents_Manager Instance { get; protected set; }

    Dictionary<int, WorldEvent> events_Map;
    List<int> currentEvents;

    public EventZone eventZone1, eventZone2, eventZone3;

    void Awake()
    {
        Instance = this;

        InitEvents();
    }

    void InitEvents()
    {
        events_Map = new Dictionary<int, WorldEvent>
        {
            {0, new WorldEvent("Modernize the Insular Police", WorldEventType.MILITARY, -2, 2, WorldEvent.EventOutCome.AGENT_HEALTH, WorldEvent.EventOutCome.NOTORIETY, 
            "New armaments and military training program for the erradication of subversive tendencies.") },
            {1, new WorldEvent("Fearmongering Headliner", WorldEventType.MEDIA, 4, 2, WorldEvent.EventOutCome.FAME, WorldEvent.EventOutCome.NOTORIETY, 
            "The press has been compromised. If the public sees us as monsters we'll never have their support.") },
            {2, new WorldEvent("Sterilization Programs", WorldEventType.POLITICS, -3, 5, WorldEvent.EventOutCome.AGENT_HEALTH, WorldEvent.EventOutCome.NOTORIETY, 
            "Senators enact Aid Program for the advancement of science and offer cash rewards to female volunteers.") },
            {3, new WorldEvent("Colonial Benefactors Ball", WorldEventType.POLITICS, 6, 6, WorldEvent.EventOutCome.FAME, WorldEvent.EventOutCome.NOTORIETY, 
            "Foreign investors flock to the Espectaculo Beach Resort & Casino to mingle with the local ruling class.") },
            {4, new WorldEvent("Airforce Strike", WorldEventType.MILITARY, -4, 4, WorldEvent.EventOutCome.AGENT_HEALTH, WorldEvent.EventOutCome.NOTORIETY, 
            "Informants close to identified subversives have located their HQ. Authorized for drop on Target.") },
            {5, new WorldEvent("Gag Law", WorldEventType.POLITICS, 3, 2, WorldEvent.EventOutCome.FAME, WorldEvent.EventOutCome.NOTORIETY, 
            "Unauthorized speeches, writings, and all mentions of independence are hereby crimes punishable by law.") },
            {6, new WorldEvent("Commercialize Agriculture", WorldEventType.POLITICS, 5, 3, WorldEvent.EventOutCome.FAME, WorldEvent.EventOutCome.NOTORIETY,
            "Farmers offered loans by foreign investors to help stimulate the economy... the foreigner's economy.") },
            {7, new WorldEvent("Governor gives presents to the poor", WorldEventType.POLITICS, 2, 1, WorldEvent.EventOutCome.FAME, WorldEvent.EventOutCome.NOTORIETY,
            "Nothing buys a vote like giving a baby a framed campaign photograph wrapped in a colorful ribbon.") },
            {8, new WorldEvent("Subversives are Heretics!", WorldEventType.MEDIA, 5, 2, WorldEvent.EventOutCome.FAME, WorldEvent.EventOutCome.NOTORIETY,
            "Convincing evidence suggests that subversives threaten are core beliefs and family values!") },

        };

        InitCurrentEvents();

    }

    void InitCurrentEvents()
    {
        currentEvents = new List<int>();

        for (int i = 0; i < events_Map.Count; i++)
        {
            currentEvents.Add(i);
        }
    }

    public void GenerateEvents()
    {
        // Generates 3 events and fills the event boxes with their info
        if (currentEvents.Count < 3)
        {
            // Loop through the events again!
            InitCurrentEvents();
        }


        // Get 3 id # from the current Deck list
        for (int i = 0; i < 3; i++)
        {
            int id = GetID();
            if (events_Map.ContainsKey(id))
            {
                WorldEvent wEvent = events_Map[id];
                Debug.Log("Event " + (i + 1) + " is " + wEvent.EventName + " and of type " + wEvent.EventType);

                UI_Manager.Instance.DisplayEvent(i, wEvent.EventType, wEvent.EventName, wEvent.EventDescription, wEvent.EventPenalty, wEvent.EventFailureOutcome,
                                                 wEvent.EventReward, wEvent.EventSuccesOutcome);

                if (i == 0)
                {
                    eventZone1.GetComponent<EventZone>().InitEventType(wEvent.EventType);
                }
                else if (i == 1)
                {
                    eventZone2.GetComponent<EventZone>().InitEventType(wEvent.EventType);

                }
                else
                {
                    eventZone3.GetComponent<EventZone>().InitEventType(wEvent.EventType);
                }

                currentEvents.Remove(id);
            }

        }
    }

    int GetID()
    {
        return currentEvents[Random.Range(0, currentEvents.Count)];
    }
}
