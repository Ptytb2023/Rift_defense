using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenVictory : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;

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

    public void SetText(string text, float delay)
    {
        StartCoroutine(ShowLine(text, delay));
    }

    private IEnumerator ShowLine(string text, float delay)
    {
        _text.text = string.Empty;
        WaitForSecondsRealtime waitForSeconds = new WaitForSecondsRealtime(delay);

        foreach (var letter in text)
        {
            _text.text += letter;
            yield return waitForSeconds;
        }

    }
}
