using Sirenix.OdinInspector;
using System.Collections.Generic;

public class InteractionAreaManager : SerializedMonoBehaviour
{
    public static InteractionAreaManager Instatnce;
    public List<InteractionArea> AllInteractionAreas;

    private void Awake() => Instatnce = this;
}
