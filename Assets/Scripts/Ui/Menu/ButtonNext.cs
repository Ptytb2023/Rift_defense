using UnityEngine;
using UnityEngine.UI;

public class ButtonNext : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _screen;
    [SerializeField] private GameObject _diabel;

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
        _screen.SetActive(true);
        _diabel.SetActive(false);
    }
}
