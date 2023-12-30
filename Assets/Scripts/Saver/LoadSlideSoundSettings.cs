using UnityEngine;
using UnityEngine.UI;

public class LoadSliderSoundSettings : LoadSettings
{
    [SerializeField] private Slider _soundSlider;
    
    public override void Awake()
    {
        base.Awake();
        _soundSlider.value = valueFloat;
    }
}