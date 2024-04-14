using System.Collections;
using UnityEngine;
using RiftDefense.Player.Container;
using TMPro;
public class ResourceView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Color _colorNoPolymer;
    [SerializeField] private float _timeColor = 1f;
    [SerializeField] private ContainerPolymers _polymer;


    private void OnEnable()
    {
        _polymer.ChangeAmoutPolymer += OnChangePolymer;
        _polymer.NotAmoutPolymer += OnNotAmoutPolymer;
    }

    private void OnDisable()
    {
        _polymer.ChangeAmoutPolymer -= OnChangePolymer;
        _polymer.NotAmoutPolymer -= OnNotAmoutPolymer;
    }

    private void OnChangePolymer(int count)
    {
        _label.text = count.ToString();
    }

    private void OnNotAmoutPolymer()
    {
        StartCoroutine(ApplyColor());
    }

    private IEnumerator ApplyColor()
    {
        var currentColor = _label.color;

        _label.color = _colorNoPolymer;
        yield return new WaitForSeconds(_timeColor);
        _label.color = currentColor;
    }
}
