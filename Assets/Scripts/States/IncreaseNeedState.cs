using System.Threading.Tasks;

public class IncreaseNeedState : State
{
    private Need _requiredNeed = new();
    private Space _space = new();
    private float _waitTime = 0f;
    public IncreaseNeedState(Bot bot, Need requiredNeed, Space space)
    {
        _bot = bot;
        _requiredNeed = requiredNeed;
        _space = space;
    }
    public override void StartState()
    {
        _waitTime = _requiredNeed.TimeToMax();
        Increase(_waitTime);
    }
    public async void Increase(float completeTime)
    {
        await Task.Delay((int)completeTime * 1000);
        _requiredNeed.NeedNotActivate();
        _space.Free();
        Done();
    }
}
