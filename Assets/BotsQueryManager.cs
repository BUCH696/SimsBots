using System.Collections.Generic;
using UnityEngine;

public class BotsQueryManager : MonoBehaviour
{
    public static BotsQueryManager Instance;
    public List<Space> walkingSpace = new();

    //TEMP
    private Space tempSpace = null;

    private void Awake() => Instance = this;

    public Queue<State> SendQuery(BotQuery query)
    {
        Queue<State> newStates;
        newStates = GetNecessaryState(ref query);
        return newStates;
    }

    private Queue<State> GetNecessaryState(ref BotQuery query)
    {
        Queue<State> tempQueueState = new();
        Need tempNeed = null;
        InteractionArea tempInteractionArea = null;

        foreach (var need in query._activeNeed)
        {
            foreach (var area in InteractionAreaManager.Instatnce.AllInteractionAreas)
            {
                if (CheckZoneOnSuitable(area, need))
                {
                    tempNeed = need;
                    tempInteractionArea = area;
                    tempSpace.Reserve(query._bot);
                    tempQueueState.Enqueue(new WalkingState(tempSpace, query._bot));
                    tempQueueState.Enqueue(new IncreaseNeedState(query._bot, tempNeed, tempSpace));
                    break;
                }
            }
        }

        if (tempNeed == null && tempInteractionArea == null)
        {
            tempSpace = walkingSpace[Random.Range(0, walkingSpace.Count)];
            tempQueueState.Enqueue(new WalkingState(tempSpace, query._bot));
        }
        return tempQueueState;
    }

    private bool CheckZoneOnSuitable(InteractionArea area, Need need)
    {
        if (area.requiredNeed.GetType() == need.GetType())
        {
            foreach (var space in area.spaces)
            {
                if (space.isBusy) continue;
                tempSpace = space;
                return true;
            }
        }
        return false;
    }

}
