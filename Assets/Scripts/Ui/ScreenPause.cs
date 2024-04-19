using System;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPause : MonoBehaviour
{
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Button _buttonContinoi;

    public Action ButtonClickExit;
    public Action ButtonClickContinio;

    private void OnEnable()
    {
        _buttonExit.onClick.AddListener(OnClickButton);
        _buttonContinoi.onClick.AddListener(OnClickContinio);
    }

    private void OnDisable()
    {
        _buttonExit.onClick.RemoveListener(OnClickButton);
        _buttonContinoi.onClick.RemoveListener(OnClickContinio);
    }


    private void OnClickButton()
    {
        ButtonClickExit?.Invoke();
    }

    private void OnClickContinio()
    {
        ButtonClickContinio?.Invoke();
    }
}
