using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class LoadPostSettigs : LoadSettings
{
  [SerializeField] private Toggle _postToggle;
  
  protected override void LoadBool()
  {
    base.LoadBool();
    Camera _camera = Camera.main;
    _camera.GetComponent<PostProcessVolume>().isGlobal = valueBool;
    _postToggle.isOn = valueBool;
  }
}
