using System.Collections;
using UnityEngine;

namespace RiftDefense.Beatle
{
    public class ClassicBeatle : BaseBeatle
    {
        protected override IEnumerator PerfomAttack()
        {
            var demage = BeatleView.DataAttackBeatle.Damage;
            var delayBetweenAttack = BeatleView.DataAttackBeatle.DelayBetweenAttack;

            while (CurrentTarget.Enabel && enabled)
            {
                CurrentTarget.ApplyDamage(demage);
                BeatleView.PrewiewAtack();
                yield return new WaitForSeconds(delayBetweenAttack);
            }
         
        }

    }
}