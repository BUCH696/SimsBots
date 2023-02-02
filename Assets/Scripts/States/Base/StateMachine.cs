using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StateMachine : Machine
{
    public Queue<State> ActiveStates = new Queue<State>();
    public NavMeshAgent navMeshAgent;
    public Bot bot { get; private set; }

    public void Awake()
    {
        bot = GetComponentInChildren<Bot>();
    }
    public override void StartMachine()
    {
        UpdateAllStates();
    }
    public override void UpdateMachine()
    {
        UpdateAllStates();
    }

    private void UpdateAllStates()
    {
        if (ActiveStates.Count == 0) return;

        if (ActiveStates.Peek().IsDone)
        {
            NextState();
            return;
        }

        ActiveStates.Peek().UpdateState();
    }
    public void AddStates(Queue<State> newStates) 
    {
        foreach (var state in newStates) ActiveStates.Enqueue(state);
    }
    public void NextState() 
    {
        ActiveStates.Dequeue(); 
        if(ActiveStates.Count > 0) 
            ActiveStates.Peek().StartState();
    }
}


