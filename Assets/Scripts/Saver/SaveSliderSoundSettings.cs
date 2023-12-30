using UnityEngine;

    public class SaveSlideSoundSettings : SaveSettings
    {
        public override void SaveFloat(float _var)
        {
            LoadSoundSettings[] _sounds = GameObject.FindObjectsOfType<LoadSoundSettings>();
            foreach (var _sound in _sounds)
            {
                _sound.Load();
            }
            
            base.SaveFloat(_var);
        }
    }
