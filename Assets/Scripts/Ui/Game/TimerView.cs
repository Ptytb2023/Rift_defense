using System;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;


    private void Update()
    {
        var time = TimeSpan.FromSeconds(Time.time);
       // _label.text = string.Format("{0:hh\\:mm\\:ss}", time);
        _label.text = string.Format("{0:mm\\:ss}", time);
    }

}
