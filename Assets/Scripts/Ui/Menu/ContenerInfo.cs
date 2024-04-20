using UnityEngine;

[CreateAssetMenu(fileName = "ContenerUI", menuName = "Contaner", order = 51)]
public class ContenerInfo : ScriptableObject
{
    public bool listenedDialog { get;  set; }

    [ContextMenu(nameof(Reseting))]
    public void Reseting()
    {
        listenedDialog = false;
    }
}
