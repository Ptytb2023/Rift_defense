using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAssistent : MonoBehaviour
{
    [SerializeField] private string _nameSound;
    [SerializeField] private AudioManger _audioManger;
    [SerializeField] private bool _isPlayAwake;

    private AudioSource _audioSource;
    private Sound _sound;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_isPlayAwake)
            PlaySound(_nameSound);
    }

    private void OnEnable()
    {
        _audioManger.ChangeVolume += OnChangeVolume;
    }

    private void OnDisable()
    {
        _audioManger.ChangeVolume -= OnChangeVolume;
    }

    private void OnChangeVolume(float volume)
    {
        _audioSource.volume = volume;
    }

    public void PlaySound(string sound)
    {
        _sound = _audioManger.GetSound(_nameSound);
        _audioSource.volume = _audioManger.CurrentVolume;
        _audioSource.clip = _sound.clip;
        _audioSource.loop = _sound.Loop;
        _audioSource.Play();
    }
}
