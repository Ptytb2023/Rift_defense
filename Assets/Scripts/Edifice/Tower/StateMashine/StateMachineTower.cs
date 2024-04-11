using RiftDefense.Beatle;
using RiftDefense.FSM;

namespace RiftDefense.Edifice.Tower.FSM
{
    public class StateMachineTower : StateMachine
    {
       public IBeatle CurrentTarget { get; set; }
    }
}
