using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SavePostSettings : SaveSettings
{
    
    public override void SaveBool(bool _var)
    {
        base.SaveBool(_var);
        Camera _camera = Camera.main;
        _camera.GetComponent<PostProcessVolume>().isGlobal = _var;
    }
}
