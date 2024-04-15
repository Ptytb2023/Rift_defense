using Lean.Pool;
using RiftDefense.Beatle;
using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class EffectLaserHit : MonoBehaviour, IPoolable
{
    [SerializeField] private ParticleSystem _efect;
    [SerializeField] private const float _durationEfect = 0.5f;

    private IBeatle _target;

  
    public void Init(IBeatle target)
    {
        _target = target;
        StartCoroutine(FollowToTarget());
    }

    private void Update()
    {
        if(_target!=null)
        transform.position = _target.GetPointForHit();
    }

    private IEnumerator FollowToTarget()
    {

        var duration = _durationEfect;
        while (duration > 0)
        {
            duration -= Time.deltaTime;

            transform.position = _target.GetPointForHit();
            yield return null;
        }

        LeanPool.Despawn(this);
    }

    public void OnDespawn()
    {
    
    }

    public void OnSpawn()
    {
      
    }
}
