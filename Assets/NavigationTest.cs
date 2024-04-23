using UnityEngine;

public class NavigationTest : MonoBehaviour
{
#if UNITY_EDITOR
    private void Awake()
    {
        UnityEditor.AI.NavMeshBuilder.Cancel();
        UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }
#endif
}
