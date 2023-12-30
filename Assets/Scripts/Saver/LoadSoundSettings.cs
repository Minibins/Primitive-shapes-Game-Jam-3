using UnityEngine;
using UnityEngine.UI;

public class LoadSoundSettings : LoadSettings
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float minus;

    public override void Awake()
    {
        base.Awake();
        Load();
    }

    public void Load()
    {
        _audioSource.volume = valueFloat / minus;
    }
}