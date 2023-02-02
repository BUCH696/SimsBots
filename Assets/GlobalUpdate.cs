using System.Collections.Generic;
using UnityEngine;

public class GlobalUpdate : MonoBehaviour
{
    public static List<Bot> allBots = new();
    public List<Bot> tempAllBots = new();

    private void Start()
    {
        tempAllBots = allBots;
        foreach (var bot in allBots)
            bot.BotStart();
    }

    private void Update()
    {
        foreach (var bot in allBots)
            bot.BotUpdate();
    }

    private void FixedUpdate()
    {
        foreach (var bot in allBots)
            bot.BotFixedUpdate();
    }
}
