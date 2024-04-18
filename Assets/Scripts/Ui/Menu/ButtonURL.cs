using UnityEngine;
using UnityEngine.UI;

public class ButtonURL : MonoBehaviour
{
    [SerializeField] private string _url;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OpenUrl);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OpenUrl);
    }

    private void OpenUrl()
    {
        Application.OpenURL(_url);
    }
}
