using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NeedMachine : Machine
{
    [SerializeField] public List<Need> Needs = new();
    [SerializeField] public List<Need> ActiveNeeds = new();

    public override void StartMachine()
    {
        DecreaseNeeds();
    }
    public override void UpdateMachine()
    {
        CheckAllNeedsOnActive();
    }

    private void CheckAllNeedsOnActive()
    {
        foreach (Need need in Needs)
        {
            if (need.IsNeed && !ActiveNeeds.Contains(need)) ActiveNeeds.Add(need);

            if (!need.IsNeed && ActiveNeeds.Contains(need))
            {
                ActiveNeeds.Remove(need);
                DecreaseNeeds();
            }
        }
    }

    public void DecreaseNeeds()
    {
        foreach (Need need in Needs)
            if(!need.IsNeed)
                StartDecrease(need);
       
    }

    public void IncreaseActiveNeeds(Need requiredNeed)
    {
        foreach (Need need in ActiveNeeds)
            if (need.IsNeed && requiredNeed.GetType() == need.GetType()) 
                StartIncrease(need);        
        
    }

    public async void StartDecrease(Need need)
    {
        await Task.Delay((int)need.TimeToZero() * 1000);
        need.NeedIsActive();
    }

    public async void StartIncrease(Need need)
    {
        await Task.Delay((int)need.TimeToMax() * 1000);
    }
}
