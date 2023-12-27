using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy),true)]
public class EnemyUI : Editor
{
    private SerializedProperty
        TimeBetweenAttacking,
        TimeBeforeAttacking;
    void OnEnable()
    { 
        TimeBeforeAttacking = FindProperty("timeBeforeAttacking");
        TimeBetweenAttacking = FindProperty("timeBetweenAttacking");
    }
    protected SerializedProperty FindProperty(string name)
    {
        return serializedObject.FindProperty(name);
    }
    public override void OnInspectorGUI()
    {
        MakeUI();
        serializedObject.ApplyModifiedProperties();
    }

    protected virtual void MakeUI()
    {
        EditorGUILayout.PropertyField(TimeBeforeAttacking,new GUIContent("����� �� ������ �����","������, ����� ���������"));
        EditorGUILayout.PropertyField(TimeBetweenAttacking,new GUIContent("����� ����� �������","����������� �����"));
    }
}
