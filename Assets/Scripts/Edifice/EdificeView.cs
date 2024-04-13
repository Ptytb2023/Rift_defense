using UnityEngine;

public class EdificeView : MonoBehaviour
{
    public void Init(Material material)
    {
        Renderer[] renderes = GetComponentsInChildren<Renderer>();

        foreach (var render in renderes)
        {
            Material[] matirials = render.materials;

            for (int i = 0; i < matirials.Length; i++)
            {
                matirials[i] = material;
            }

            render.materials = matirials;
        }
    }
}
