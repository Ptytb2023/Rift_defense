using Lean.Pool;
using UnityEngine;

public class EffectTowerDead : MonoBehaviour, IPoolable
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void OnDespawn()
    {
      
    }

    public void OnSpawn()
    {
        _particleSystem.Play();

        LeanPool.Despawn(this, 3f);
    }
}
