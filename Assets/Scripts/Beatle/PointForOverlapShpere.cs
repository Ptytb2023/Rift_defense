using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForOverlapShpere : MonoBehaviour
{
    [SerializeField] private BaseBeatleView _beatleView;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(transform.position, _beatleView.DataAttackBeatle.radiusPointAttack);
    }
   
}
