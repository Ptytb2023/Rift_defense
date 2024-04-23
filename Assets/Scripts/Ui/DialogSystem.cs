using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private TMP_Text _label;

    [TextArea()]
    [SerializeField] private string[] _text;

    private WaitForSeconds _sleep;
    private const float _secondSleep = 0.001f;
    private int _currentIndexLine;

    public Action EndDialog;


    private void OnEnable()
    {
        _currentIndexLine = 0;
        _sleep = new WaitForSeconds(_secondSleep);

        _nextButton.onClick.AddListener(NextMessage);
        NextMessage();
    }

    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(NextMessage);
    }

    public void NextMessage()
    {
        _nextButton.enabled = false;
        _label.text = string.Empty;
        if (_currentIndexLine < _text.Length)
            StartCoroutine(ShowLine(_text[_currentIndexLine]));
        else
        {
            EndDialog?.Invoke();
            gameObject.SetActive(false);
        }
            _currentIndexLine++;
    }


    private IEnumerator ShowLine(string massege)
    {
        foreach (var letter in massege)
        {
            _label.text += letter;
            yield return _sleep;
        }
        _nextButton.enabled = true;
    }

}
