using UnityEngine;
using System.Collections;

public class Company_Manager  {

    // number of Agents that can be employed
    int agentRoster;
    public int AgentRoster { get { return agentRoster; } }

    // player score
    int notoriety = 0;

    // player currency used to activate agents, play actions or equip weapons/consumables
    int gold;
    public int Gold { get { return gold; } }

    string companyName;
    public string CompanyName { get { return companyName; } }

    public Company_Manager(string name, int roster = 3, int money = 100, int not = 0)
    {
        companyName = name;
        agentRoster = roster;
        notoriety = not;
        gold = money;
    }

    public void SubtractFromRoster(int change)
    {
        agentRoster -= change;
    }
}
