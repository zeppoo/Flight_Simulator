using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AeroEngine))]
public class AeroEnginePropertyDrawer : PropertyDrawer
{
    private SerializedProperty _engineType;
    private SerializedProperty _position;
    private SerializedProperty _direction;
    private SerializedProperty _thrust;
    private SerializedProperty _throttle;
    private SerializedProperty _efficiency;
    private SerializedProperty _impulse;
    private SerializedProperty _rps;
    private SerializedProperty _diameter;
    private SerializedProperty _thrustCo;
    private SerializedProperty _inletWidth;
    private SerializedProperty _inletHeight;
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        
        EditorGUI.BeginProperty(position, label, property);

        //find properties
        _engineType = property.FindPropertyRelative("_engineType");
        _position = property.FindPropertyRelative("_position");
        _direction = property.FindPropertyRelative("_direction");
        _thrust = property.FindPropertyRelative("_thrust");
        _throttle = property.FindPropertyRelative("_throttle");
        _efficiency = property.FindPropertyRelative("_efficiency");
        _impulse = property.FindPropertyRelative("_impulse");
        _rps = property.FindPropertyRelative("_rps");
        _diameter = property.FindPropertyRelative("_diameter");
        _thrustCo = property.FindPropertyRelative("_thrustCo");
        _inletWidth = property.FindPropertyRelative("_inletWidth");
        _inletHeight = property.FindPropertyRelative("_inletHeight");

        //drawing instructions here
        Rect foldOutBox = new Rect(position.xMin, position.yMin, 
            position.size.x, EditorGUIUtility.singleLineHeight);
        property.isExpanded = EditorGUI.Foldout(foldOutBox, property.isExpanded, label);
        if (property.isExpanded)
        {
            DrawProperties(position);
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty findType = property.FindPropertyRelative("_engineType");
        EngineType engineType = (EngineType)findType.enumValueIndex;
        int lines = 1; // Default number of lines

        if (property.isExpanded)
        {
            lines += engineType == EngineType.Propeller ? 9 : 8;
        }

        return EditorGUIUtility.singleLineHeight * lines;
    }

    private void DrawProperties(Rect position)
    {
        float xPos = position.xMin;
        float yPos = position.yMin;
        float width = position.size.x;
        float height = EditorGUIUtility.singleLineHeight;

        Rect area = new Rect(xPos, yPos, width, height);
        
        EditorGUI.PropertyField(area = NewLine(area), _engineType, new GUIContent("Engine Type"));
        EditorGUI.PropertyField(area = NewLine(area), _position, new GUIContent("Position"));
        EditorGUI.PropertyField(area = NewLine(area), _direction, new GUIContent("Direction"));
        EditorGUI.PropertyField(area = NewLine(area), _thrust, new GUIContent("Thrust"));
        EditorGUI.PropertyField(area = NewLine(area), _throttle, new GUIContent("Throttle"));

        switch ((EngineType)_engineType.enumValueIndex)
        {
            case EngineType.Propeller:
                EditorGUI.PropertyField(area = NewLine(area), _efficiency, new GUIContent("Efficiency"));
                EditorGUI.PropertyField(area = NewLine(area), _rps, new GUIContent("R.P.S."));
                EditorGUI.PropertyField(area = NewLine(area), _diameter, new GUIContent("Throttle"));
                EditorGUI.PropertyField(area = NewLine(area), _thrustCo, new GUIContent("Thrust Coefficient"));
                break;
            case EngineType.Jet:
                EditorGUI.PropertyField(area = NewLine(area), _impulse, new GUIContent("Impulse"));
                EditorGUI.PropertyField(area = NewLine(area), _inletWidth, new GUIContent("Inlet Width"));
                EditorGUI.PropertyField(area = NewLine(area), _inletHeight, new GUIContent("Inlet Height"));
                break;
        }
    }

    private Rect NewLine(Rect rect)
    {
        rect.y += EditorGUIUtility.singleLineHeight;
        return rect;
    }
}


