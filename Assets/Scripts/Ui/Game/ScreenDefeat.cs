using System;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDefeat : MonoBehaviour
{
    [SerializeField] private Button _button;

    public Action ButtonClickMenu;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickButton);
    }


    private void OnClickButton()
    {
        ButtonClickMenu?.Invoke();
    }
}
