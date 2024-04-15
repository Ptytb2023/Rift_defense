using RiftDefense.Beatle.Model;
using RiftDefense.Generic;
using UnityEngine;

namespace RiftDefense.Beatle
{
    public class BeatleView : MonoBehaviour
    {
        [field: SerializeField] public DataAnimationBeatle DataAnimationBeatle;
        [field: SerializeField] public DataHealf DataHealf { get; private set; }
        [field: SerializeField] public DataAttackBeatle DataAttackBeatle { get; private set; }
        [field: SerializeField] public DataMoveBeatle DataMoveBeatle { get; private set; }
        [field: SerializeField] public Transform PointToHit { get; private set; }

        private Animator _animator=> DataAnimationBeatle.Animator;


        public void PrewiewDamage()
        {

        }

        public void PrewiewAtack()
        {
            _animator.SetTrigger(DataAnimationBeatle.Attack);
        }

        public void ShowDead()
        {
            _animator.Play(DataAnimationBeatle.Dead);

        }
      
        public void SetActiovMove(bool active)
        {
            _animator.SetBool(DataAnimationBeatle.Move, active);
        }
    }
}
