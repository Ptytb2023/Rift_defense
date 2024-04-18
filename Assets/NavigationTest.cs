using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationTest : MonoBehaviour
{
    private void Awake()
    {
        UnityEditor.AI.NavMeshBuilder.Cancel();
        UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }
}
