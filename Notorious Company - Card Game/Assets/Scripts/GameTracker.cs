using UnityEngine;
using System.Collections;

public class GameTracker : MonoBehaviour {

    public static GameTracker Instance { get; protected set; }

    int fame = 0;
    public int Fame { get { return fame; } }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        UI_Manager.Instance.ChangeNotoriety(0);
        AddFame(0);
    }

    public void AddFame(int x)
    {
        fame += x;
        UI_Manager.Instance.ChangeFame(fame);
    }

}
