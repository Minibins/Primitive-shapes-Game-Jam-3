using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(MoveEnemy),false)]
public class MoveEnemyUI : EnemyUI
{
    private SerializedProperty _speed;
    private void OnEnable()
    {
        _speed = FindProperty("_speed");
    }
    protected override void MakeUI()
    {
        base.MakeUI();
      //  EditorGUILayout.PropertyField(_speed,new GUIContent("Скорость","Скорость движения к игроку"));
    }
}
