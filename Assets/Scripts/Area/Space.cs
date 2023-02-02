using UnityEngine;

public class Space : MonoBehaviour
{
    public Bot Bot;
    public bool isBusy = false;

    public void Reserve(Bot bot)
    {
        Bot = bot;
        isBusy = true;
    }

    public void Free()
    {
        Bot = null;
        isBusy = false;
    }
}

