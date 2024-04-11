using System.Collections.Generic;

namespace RiftDefense.Generic.Interface
{
    public interface IHandlerSearchObject<T>
    {
        public IEnumerable<T> GetObjectsInRadius();
    }
}