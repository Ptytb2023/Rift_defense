using Lean.Pool;
using RiftDefense.Beatle;
using RiftDefense.Beatle.Model;
using RiftDefense.Edifice.Tower;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

public abstract class BaseBeatleView : MonoBehaviour, IBeatle, IPoolable
{
    [field: SerializeField] public bool isAllTarget { get; private set; }
    [field: SerializeField] public int MaxCapacityTarget { get; private set; }
    public int CurrentCoutTarget { get; set; }

    [SerializeField] private Collider _collider;
    [SerializeField] private BaseBeatle _beasBeatle;
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
        DataAnimationBeatle.Animator.SetTrigger(DataAnimationBeatle.Attack);
    }

    public void LookAtTarget(ITower tower)
    {
        transform.LookAt(tower.GetPosition());
    }

    public void ShowDead()
    {
        DataAnimationBeatle.Animator.Play(DataAnimationBeatle.Dead);
    }

    public void SetActiovMove(bool active)
    {
        if (active)
            DataAnimationBeatle.Animator.SetBool(DataAnimationBeatle.Move, active);
        else
        {
            DataAnimationBeatle.Animator.SetBool(DataAnimationBeatle.Move, active);
        }
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
        CurrentCoutTarget = 0;
        _beasBeatle.enabled = true;
        Enabel = true;
        _collider.enabled = true;
        DataHealf.ResetDataHealf();
        DataHealf.Dead += OnDead;
    }

    public virtual void OnDespawn()
    {
        DataHealf.Dead -= OnDead;
        PrewiewDamage();
    }

    protected virtual void OnDead()
    {
        _beasBeatle.enabled = false;
        Dead?.Invoke(this);
        Enabel = false;
        ShowDead();
        _collider.enabled = false;
        LeanPool.Despawn(this, 3f);
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawSphere(transform.position, DataAttackBeatle.RadiusSearch);

    //}

    public bool AddEnemyTarget(IEnemy enemy)
    {
        if (CurrentCoutTarget >= MaxCapacityTarget)
            return false;

        if (!isAllTarget)
            if (MaxCapacityTarget / 2 <= CurrentCoutTarget)
            {
                int chanche = UnityEngine.Random.Range(0, 100);

                if (chanche > 50)
                {
                    CurrentCoutTarget++;
                    enemy.Dead += OnEnemyDeadTarget;
                    return true;
                }
                else
                    return false;
            }

        CurrentCoutTarget++;
        enemy.Dead += OnEnemyDeadTarget;
        return true;
    }

    private void OnEnemyDeadTarget(IEnemy enemy)
    {
        enemy.Dead -= OnEnemyDeadTarget;
        CurrentCoutTarget--;
    }

}
