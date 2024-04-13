using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RiftDefense.Player.Container;
using TMPro;
public class ResourceView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private ContainerPolymers _polymer;


    private void OnEnable()
    {
        _polymer.ChangeAmoutPolymer += OnChangePolymer;
    }

    private void OnDisable()
    {
        _polymer.ChangeAmoutPolymer += OnChangePolymer;
    }

    private void OnChangePolymer(int count)
    {
        _label.text = count.ToString();
    }
}
