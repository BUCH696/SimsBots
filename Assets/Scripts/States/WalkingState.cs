using UnityEngine.AI;

public class WalkingState : State
{
    private Space _nextSpace;
    private NavMeshAgent _currentNavMeshAgent;

    public WalkingState(Space nextSpace, Bot bot)
    {
        _nextSpace = nextSpace;
        _currentNavMeshAgent = bot.stateMachine.navMeshAgent;
        _bot = bot;
    }

    public override void UpdateState() => Walk();
    
    public void Walk()
    {
        _currentNavMeshAgent.SetDestination(_nextSpace.transform.position);
        if(_currentNavMeshAgent.remainingDistance <= 1f && !_currentNavMeshAgent.pathPending) Done();
    }

}
