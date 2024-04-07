using RiftDefense.Edifice;
using RiftDefense.PlacmentSystem.Presenter;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonBuilding : MonoBehaviour
{
    [SerializeField] private PlacmentSystemPresenter _placmentSystem;
    [SerializeField] private EdificePlacmentMainView _edificeTemplate;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickBuilding);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickBuilding);
    }

    private void OnClickBuilding()
    {
        var edifice = Instantiate(_edificeTemplate);
        _placmentSystem.StartPlacement(edifice);
    }
}
