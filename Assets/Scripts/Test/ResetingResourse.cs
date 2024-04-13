using RiftDefense.Player.Container;
using UnityEngine;

public class ResetingResourse : MonoBehaviour
{
    [SerializeField] private ContainerPolymers _polimers;


    private void Start()
    {
        _polimers.Resetiong();
    }
}
