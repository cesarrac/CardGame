using UnityEngine;
using System.Collections;

[System.Serializable]
public enum WorldEventType { MILITARY, POLITICS, MEDIA, CORPORATIONS, NONE, ALL}

[System.Serializable]
public class WorldEvent
{
    string eventName;
    public string EventName { get { return eventName; } }

    string eventDescription;
    public string EventDescription { get { return eventDescription; } }

    int eventPenalty;
    public int EventPenalty { get { return eventPenalty; } }

    int eventReward;
    public int EventReward { get { return eventReward; } }

    WorldEventType eventType;
    public WorldEventType EventType { get { return eventType; } }

    public enum EventOutCome { AGENT_HEALTH, FAME, NOTORIETY }

    EventOutCome eventFailureOutcome;
    public EventOutCome EventFailureOutcome { get { return eventFailureOutcome; } }

    EventOutCome eventSuccesOutcome;
    public EventOutCome EventSuccesOutcome { get { return eventSuccesOutcome; } }

    public WorldEvent(string name, WorldEventType eType, int penalty, int reward, EventOutCome outcomeFail, EventOutCome outcomeSuccess, string desc)
    {
        eventName = name;
        eventDescription = desc;
        eventPenalty = penalty;
        eventReward = reward;
        eventFailureOutcome = outcomeFail;
        eventSuccesOutcome = outcomeSuccess;

        eventType = eType;
    }

}
