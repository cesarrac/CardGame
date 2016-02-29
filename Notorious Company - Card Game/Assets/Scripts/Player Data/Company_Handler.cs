using UnityEngine;
using System.Collections;

public class Company_Handler : MonoBehaviour {

    public static Company_Handler Instance { get; protected set; }

    Company_Manager theCompany;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        NewCompany();
    }

    // TODO: as an argument I can pass in some sort of difficulty to create new company with different starting stats
    public void NewCompany(string name = "The Guild")
    {
        // New Company with all the default starting stats!
        theCompany = new Company_Manager(name);
    }

    public int GetCurrRosterTotal()
    {
        return theCompany.AgentRoster;
    }

    public bool AddAgent(int cost)
    {
        Debug.Log("Adding Agent!");
        if (theCompany.AgentRoster >= cost)
        {
     
            theCompany.ChangeRoster(cost);

            Debug.Log("Company roster now equals " + theCompany.AgentRoster);
            return true;
        }
          
        else
            return false;
    }



    // TODO: Load game
    //public void LoadCompany(Company_Manager company)
    //{
    //    theCompany = company;
    //}
}
