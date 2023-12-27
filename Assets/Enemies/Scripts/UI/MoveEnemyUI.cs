using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(MoveEnemy),false)]
public class MoveEnemyUI : EnemyUI
{
    private SerializedProperty speed;
    private void OnEnable()
    {
        speed = FindProperty("Speed");
    }
    protected override void MakeUI()
    {
        base.MakeUI();
        EditorGUILayout.PropertyField(speed,new GUIContent("Скорость","Скорость движения к игроку"));
    }
}
