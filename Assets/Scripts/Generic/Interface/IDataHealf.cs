namespace RiftDefense.Generic.Interface
{
    public interface IDataHealf : IDamageable
    {
        float CurrentHealf { get; }
        float MaxHealf { get; }

        void ResetDataHealf();
    }
}