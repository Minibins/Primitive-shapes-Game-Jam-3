using UnityEngine;

    public class SaveSoundSettings : SaveSettings
    {
        [SerializeField] private AudioSource _audioSource;
        
        public override void SaveFloat(float _var)
        {
            _audioSource.volume = _var;
            base.SaveFloat(_var);
        }
    }
