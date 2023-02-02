using Sirenix.OdinInspector;

public abstract class Machine : SerializedMonoBehaviour
{
    public virtual void UpdateMachine() { }
    public virtual void FixedUpdateMachine() { }
    public virtual void StartMachine() { }
}
