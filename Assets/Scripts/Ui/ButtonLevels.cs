using MushroomMadness.UI.LoadScene;
using RiftDefense.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevels : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _indexScene;
    [SerializeField] private SceneLoadManager _sceneLoadManager;
    [SerializeField] private ScreenLoadGame _screen;
    [SerializeField] private string _nameLevel;
    [SerializeField] private TMP_Text _labelScore;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnLevelLoad);
        _labelScore.text = LoadScore().ToString();
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

    private int LoadScore()
    {
       return PlayerPrefs.GetInt(_nameLevel, 0000);
    }
}
