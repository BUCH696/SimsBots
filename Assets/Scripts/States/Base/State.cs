
public class State
{
    public Bot _bot;
    public bool IsDone = false;
    public void Done() { IsDone = true; }
    public virtual void UpdateState() { }
    public virtual void StartState() { }
}
