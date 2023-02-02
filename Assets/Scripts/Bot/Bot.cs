using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public StateMachine stateMachine;
    public NeedMachine needMachine;
    public GameObject BOT;
    public bool spawn = false;
    public BotQuery Query { get; private set; }
    private void Awake()
    {
        GlobalUpdate.allBots.Add(this);
        needMachine.Needs.Add(new FoodNeed(Random.Range(50,200), Random.Range(1, 5)));
        needMachine.Needs.Add(new RestNeed(Random.Range(50, 200), Random.Range(1, 5)));
        needMachine.Needs.Add(new SwimNeeds(Random.Range(50, 200), Random.Range(1, 5)));
    }

    public void BotStart()
    {
        TimeOut();
        print("Загрузил Start");
    }

    public void BotUpdate()
    {
        stateMachine.UpdateMachine();
        needMachine.UpdateMachine();
    }

    public void BotFixedUpdate()
    {
        if (stateMachine.ActiveStates.Count == 0)
        {
            stateMachine.AddStates(CreateNewQuery());
        }
    }
    private Queue<State> CreateNewQuery()
    {
        BotQuery newQuery = new BotQuery(needMachine.ActiveNeeds, this);
        Queue<State> tempQueueState;
        tempQueueState = BotsQueryManager.Instance.SendQuery(newQuery);
        return tempQueueState;
    }

    private async void TimeOut()
    {
        await Task.Delay(2000);
        spawn = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bot") && spawn)
        {
            spawn = false;
            Instantiate(BOT, transform.position, transform.rotation);
            TimeOut();
        }
    }
}
