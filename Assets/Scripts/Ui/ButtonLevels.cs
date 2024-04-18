using MushroomMadness.UI.LoadScene;
using RiftDefense.UI;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevels : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _indexScene;
    [SerializeField] private SceneLoadManager _sceneLoadManager;
    [SerializeField] private ScreenLoadGame _screen;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnLevelLoad);
    }


    private void OnDisable()
    {
        _button.onClick?.RemoveListener(OnLevelLoad);
    }

    private void OnLevelLoad()
    {
        _sceneLoadManager.LoadScene(_indexScene);
        _screen.gameObject.SetActive(true);
    }
}
