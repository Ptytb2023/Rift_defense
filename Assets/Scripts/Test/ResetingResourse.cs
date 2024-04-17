using RiftDefense.Player.Container;
using UnityEngine;

public class ResetingResourse : MonoBehaviour
{
    [SerializeField] private ContainerPolymers _polimers;


    private void Awake()
    {
        _polimers.Resetiong();
    }
}
