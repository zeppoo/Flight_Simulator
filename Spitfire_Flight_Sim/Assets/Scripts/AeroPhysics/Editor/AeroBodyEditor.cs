using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(AeroBody))]
public class AeroBodyEditor : UnityEditor.Editor
{
    private SerializedProperty _debugMode;
    private SerializedProperty _rb;
    private SerializedProperty _weight;
    private SerializedProperty _unit;
    private SerializedProperty _velocity;
    private SerializedProperty _altitude;
    private SerializedProperty _airDensity;
    private SerializedProperty _aeroSurfaces;
    private SerializedProperty _aeroEngines;

    private void OnEnable()
    {
        _debugMode = serializedObject.FindProperty("_debugMode");
        _rb = serializedObject.FindProperty("_rb");
        _weight = serializedObject.FindProperty("_weight");
        _unit = serializedObject.FindProperty("_unit");
        _velocity = serializedObject.FindProperty("_velocity");
        _altitude = serializedObject.FindProperty("_altitude");
        _airDensity = serializedObject.FindProperty("_airDensity");
        _aeroSurfaces = serializedObject.FindProperty("_aeroSurfaces");
        _aeroEngines = serializedObject.FindProperty("_aeroEngines");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        EditorGUILayout.PropertyField(_debugMode, new GUIContent("Debug Mode"));
        EditorGUILayout.Space(10);
        DrawDefaultFields();

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawDefaultFields()
    {
        EditorGUILayout.PropertyField(_rb, new GUIContent("Rigid Body"));
        if (_rb.objectReferenceValue == null)
        {
            EditorGUILayout.HelpBox("This component is depended on a RigidBody", MessageType.Error);
        }
        EditorGUILayout.Space(10);

        //begin horizontal
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(_weight, new GUIContent("Weight"));
        EditorGUIUtility.labelWidth = 30;
        EditorGUILayout.PropertyField(_unit, new GUIContent(""));
        EditorGUIUtility.labelWidth = 0;
        EditorGUILayout.EndHorizontal();
        //end horizontal
        
        EditorGUILayout.Space(10);
        
        //check if you need to draw debug fields
        if (_debugMode.boolValue == true)
        {
            DrawDebugFields();
        }
        
        EditorGUILayout.PropertyField(_aeroSurfaces, new GUIContent("Aero Surfaces:"));
        if (_aeroSurfaces.arraySize == 0)
        {
            EditorGUILayout.HelpBox("There aren't any Aero Surfaces assigned", MessageType.Warning);
        }
        EditorGUILayout.Space(10);
        EditorGUILayout.PropertyField(_aeroEngines, new GUIContent("Aero Engines:"));
        if (_aeroEngines.arraySize == 0)
        {
            EditorGUILayout.HelpBox("There aren't any Aero Engines assigned", MessageType.Warning);
        }
    }

    private void DrawDebugFields()
    {
        EditorGUILayout.LabelField("Debugging stats", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_velocity, new GUIContent("Velocity"));
        EditorGUILayout.Space(5);
        EditorGUILayout.PropertyField(_altitude, new GUIContent("Altitude"));
        EditorGUILayout.Space(5);
        EditorGUILayout.PropertyField(_airDensity, new GUIContent("Air Density"));
        EditorGUILayout.Space(5);
    }
}


