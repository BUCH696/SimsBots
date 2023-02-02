
public class Need
{
    public int _maxAmount { get; private set; }
    public int _amountSpeed { get; private set; }
    public bool IsNeed { get; private set; }

    public Need(int maxAmount = 100, int amountSpeed = 2, bool isNeed = false)
    {
        _maxAmount = maxAmount;
        _amountSpeed = amountSpeed;
        this.IsNeed = isNeed;
    }

    public Need() { }

    public void NeedNotActivate() { IsNeed = false; }
    public void NeedIsActive() { IsNeed = true; }

    public void ChangeAmoundSpeed(int speed) => _amountSpeed = speed;
    public void ChangeMaxAmound(int maxAmount) => _maxAmount = maxAmount;

    public float TimeToMax() { return _maxAmount / _amountSpeed; }
    public float TimeToZero() { return (_maxAmount / _amountSpeed) / 2; }
}
