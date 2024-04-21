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

    private Coroutine _coroutine;
    Color _currentColor;

    private void Awake()
    {
        _currentColor = _label.color;
    }

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
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _label.color = _currentColor;
        }
        _coroutine = StartCoroutine(ApplyColor());
    }

    private IEnumerator ApplyColor()
    {
        _label.color = _colorNoPolymer;
        yield return new WaitForSeconds(_timeColor);
        _label.color = _currentColor;
    }


}
