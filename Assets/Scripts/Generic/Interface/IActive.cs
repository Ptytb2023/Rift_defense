
namespace RiftDefense.Generic.Interface
{
    public interface IActive
    {
        public bool Enabel { get; }
        public void SetActive(bool active);
    }
}