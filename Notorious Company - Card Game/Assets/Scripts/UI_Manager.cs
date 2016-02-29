using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public static UI_Manager Instance { get; protected set; }


    public Text notoriety_score, fame_total;

    // Events
    public Text eventOneName, eventOneDesc, eventOnePenalty, eventOnePenaltyType, eventOneReward, eventOneRewardType;
    public Text eventTwoName, eventTwoDesc, eventTwoPenalty, eventTwoPenaltyType, eventTwoReward, eventTwoRewardType;
    public Text eventThreeName, eventThreeDesc, eventThreePenalty, eventThreePenaltyType, eventThreeReward, eventThreeRewardType;
    public Text eventOneType, eventTwoType, eventThreeType;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeFame(int change)
    {
        fame_total.text = change.ToString();
    }

    public void ChangeNotoriety(int change)
    {
        notoriety_score.text = change.ToString();
    }

    public void DisplayEvent(int eventNum, WorldEventType eventType, string name, string desc, int penalty, WorldEvent.EventOutCome penaltyType, int reward, WorldEvent.EventOutCome rewardType)
    {
        if (eventNum == 1)
        {
            eventOneName.text = name;
            eventOneDesc.text = desc;
            eventOnePenalty.text = penalty.ToString();
            eventOnePenaltyType.text = penaltyType.ToString();
            eventOneReward.text = penalty.ToString();
            eventOneRewardType.text = penaltyType.ToString();
            eventOneType.text = eventType.ToString();
        }
        else if (eventNum == 2)
        {
            eventTwoName.text = name;
            eventTwoDesc.text = desc;
            eventTwoPenalty.text = penalty.ToString();
            eventTwoPenaltyType.text = penaltyType.ToString();
            eventTwoReward.text = penalty.ToString();
            eventTwoRewardType.text = penaltyType.ToString();
            eventTwoType.text = eventType.ToString();
        }
        else
        {
            eventThreeName.text = name;
            eventThreeDesc.text = desc;
            eventThreePenalty.text = penalty.ToString();
            eventThreePenaltyType.text = penaltyType.ToString();
            eventThreeReward.text = penalty.ToString();
            eventThreeRewardType.text = penaltyType.ToString();
            eventThreeType.text = eventType.ToString();
        }
    }


}
