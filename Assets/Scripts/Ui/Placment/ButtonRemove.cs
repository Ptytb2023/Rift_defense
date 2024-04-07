using RiftDefense.PlacmentSystem.Presenter;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonRemove : MonoBehaviour
{
    [SerializeField] private PlacmentSystemPresenter _placmentSystem;

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
        _placmentSystem.StartPlacement(null,TypePlacement.Remove);
    }
}
