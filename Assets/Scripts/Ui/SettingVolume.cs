using UnityEngine;
using UnityEngine.UI;

public class SettingVolume : MonoBehaviour
{
    [SerializeField] private AudioManger _audioManger;
    [SerializeField] private Slider _slider;

    public void ChengaeVolume()
    {
        _audioManger.SetVoilume(_slider.value);
    }
}
