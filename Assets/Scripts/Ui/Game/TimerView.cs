using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;

    private WaitForSeconds _delay;

    private float _time;
    private float _delaySecond;

    private void Awake()
    {
        _delaySecond = 1f;
        _delay = new WaitForSeconds(_delaySecond);
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (gameObject.activeSelf)
        {
            _time += _delaySecond;
            var time = TimeSpan.FromSeconds(_time);
            _label.text = string.Format("{0:mm\\:ss}", time);
            yield return _delay;
        }
    }

}
