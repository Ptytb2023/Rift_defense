using System;
using System.Collections;

namespace RiftDefense.Generic.Interface
{
    public interface IRealod
    {
        public event Action NeedReload;
        public IEnumerator ApplyDelay();
        public IEnumerator Reload();
    }
}