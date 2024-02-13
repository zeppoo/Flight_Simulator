using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AeroSurface))]
public class AeroSurfaceEditor : Editor
{
    private SerializedProperty surfaceSize;
    private SerializedProperty flapsSize;
    private SerializedProperty liftSlope;
    private SerializedProperty normal;
    private SerializedProperty size;

    private void OnEnable()
    {
    surfaceSize = serializedObject.FindProperty("surfaceSize");
    flapsSize = serializedObject.FindProperty("flapSize");
    liftSlope = serializedObject.FindProperty("liftSlope");
    normal = serializedObject.FindProperty("normal");
    size = serializedObject.FindProperty("size");
    }

    public override void OnInspectorGUI()
    {
        AeroSurface data = (AeroSurface)target;
        base.OnInspectorGUI();
        EditorGUILayout.PropertyField(surfaceSize, new GUIContent("Surface Size"));
        EditorGUILayout.PropertyField(flapsSize, new GUIContent("Flap Size"));
        EditorGUILayout.PropertyField(liftSlope, new GUIContent("Lift Slope"));
        EditorGUILayout.PropertyField(normal, new GUIContent("Normal"));
        EditorGUILayout.PropertyField(size, new GUIContent("Size"));

    }
}
