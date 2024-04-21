using UnityEngine;
using UnityEngine.UI;

public class SettingVolume : MonoBehaviour
{
    [SerializeField] private AudioManger _audioManger;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        Reset();
    }

    public void ChengaeVolume()
    {
        _audioManger.SetVoilume(_slider.value);
        Save();
    }


    private void Save()
    {
        PlayerPrefs.SetFloat(nameof(_audioManger.CurrentVolume), _audioManger.CurrentVolume);
    }

    public void Reset()
    {
        var volume = PlayerPrefs.GetFloat(nameof(_audioManger.CurrentVolume), 0.3f);

        _audioManger.SetVoilume(volume);
        _slider.value = volume;
    }
}
