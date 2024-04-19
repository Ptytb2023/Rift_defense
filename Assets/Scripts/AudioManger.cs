using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AdioManager", menuName = "SettingsGame/AdioManager", order = 51)]
public class AudioManger : ScriptableObject
{
    [SerializeField] private Sound[] _musicSounds;

    public float CurrentVolume { get; private set; }
    public Action<float> ChangeVolume;

    public Sound GetSound(string name)
    {
        var sound = Array.Find(_musicSounds, x => x.name == name);

        if (sound == null)
            throw new NullReferenceException(name);

        return sound;
    }

    public void SetVoilume(float volume)
    {
        CurrentVolume = volume;
        ChangeVolume?.Invoke(volume);
    }
}
[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool Loop;
}