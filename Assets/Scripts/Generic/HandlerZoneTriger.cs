using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HandlerZoneTriger : MonoBehaviour
{
    private SphereCollider _sphereCollider;

    public event Action<Collider> EneterTriget;
    public event Action<Collider> ExitTriger;

    public void Init(float radiusAtack)
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.isTrigger = true;
        _sphereCollider.radius = radiusAtack;
    }

    private void OnTriggerEnter(Collider other)
    {
        EneterTriget?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ExitTriger?.Invoke(other);
    }
}
