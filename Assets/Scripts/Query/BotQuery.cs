using System.Collections.Generic;

public class BotQuery
{
    public List<Need> _activeNeed { get; private set; }
    public Bot _bot { get; private set; }

    public BotQuery(List<Need> activeNeed, Bot bot)
    {
        _activeNeed = activeNeed;
        _bot = bot;
    }
}
