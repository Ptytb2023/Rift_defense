using Lean.Pool;
using RiftDefense.Beatle;
using RiftDefense.Beatle.Model;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;
using TMPro.EditorUtilities;
using UnityEngine;

public abstract class BaseBeatleView : MonoBehaviour, IBeatle, IPoolable
{
    [field: SerializeField] public DataAnimationBeatle DataAnimationBeatle;

    public event Action<IEnemy> Dead;

    [field: SerializeField] public DataHealf DataHealf { get; private set; }
    [field: SerializeField] public DataAttackBeatle DataAttackBeatle { get; private set; }
    [field: SerializeField] public DataMoveBeatle DataMoveBeatle { get; private set; }

    [field: SerializeField] public Transform PointToHit { get; private set; }

    public Vector3 Destination { get; private set; }

    public bool Enabel { get; protected set; }

    protected virtual void Awake()
    {
        var mainTower = FindObjectOfType<MainTower>();
        Destination = mainTower.GetPosition();
    }

    public void PrewiewDamage()
    {

    }

    public void PrewiewAtack()
    {
    }

    public void ShowDead()
    {
    }

    public void SetActiovMove(bool active)
    {
    }

    public Vector3 GetPointForHit()
    {
        return PointToHit.position;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void ApplyDamage(float damage)
    {
       DataHealf.ApplyDamage(damage);
    }

    public virtual void OnSpawn()
    {
        
    }

    public virtual void OnDespawn()
    {
   
    }
}
