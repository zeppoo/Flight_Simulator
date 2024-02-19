using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AeroSurface))]
public class AeroSurfacePropertyDrawer : PropertyDrawer
{
    private SerializedProperty _controlType;
    private SerializedProperty _lift;
    private SerializedProperty _chord;
    private SerializedProperty _span;
    private SerializedProperty _wingArea;
    private SerializedProperty _controlSize;
    private SerializedProperty _aoa;
    private SerializedProperty _stallAngle;
    private SerializedProperty _zeroLiftAngle;
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        
        EditorGUI.BeginProperty(position, label, property);

        //find properties
        _controlType = property.FindPropertyRelative("_controlType");
        _lift = property.FindPropertyRelative("_lift");
        _chord = property.FindPropertyRelative("_chord");
        _span = property.FindPropertyRelative("_span");
        _wingArea = property.FindPropertyRelative("_wingArea");
        _controlSize = property.FindPropertyRelative("_controlSize");
        _aoa = property.FindPropertyRelative("_aoa");
        _stallAngle = property.FindPropertyRelative("_stallAngle");
        _zeroLiftAngle = property.FindPropertyRelative("_zeroLiftAngle");

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
        SerializedProperty findType = property.FindPropertyRelative("_controlType");
        ControlType controlType = (ControlType)findType.enumValueIndex;
        int lines = 1; // Default number of lines

        if (property.isExpanded)
        {
            lines += controlType == ControlType.None ? 4 : 9;
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
        
        

        switch ((ControlType)_controlType.enumValueIndex)
        {
            case ControlType.None:
                DrawNormalProperties(area);
                break;
            case ControlType.flap:
                DrawControlProperties(area);
                break;
            case ControlType.aeleron:
                DrawControlProperties(area);
                break;
            case ControlType.ruli:
                DrawControlProperties(area);
                break;
            case ControlType.rudder:
                DrawControlProperties(area);
                break;
        }
    }

    private void DrawNormalProperties(Rect area)
    {
        EditorGUI.PropertyField(area = NewLine(area), _controlType, new GUIContent("Control Type"));
        EditorGUI.PropertyField(area = NewLine(area), _chord, new GUIContent("Width"));
        EditorGUI.PropertyField(area = NewLine(area), _span, new GUIContent("Length"));
        EditorGUI.PropertyField(NewLine(area), _wingArea, new GUIContent("Total Area"));

    }

    private void DrawControlProperties(Rect area)
    {
        EditorGUI.PropertyField(area = NewLine(area), _controlType, new GUIContent("Control Type"));
        EditorGUI.PropertyField(area = NewLine(area), _lift, new GUIContent("Lift Force"));
        EditorGUI.PropertyField(area = NewLine(area), _chord, new GUIContent("Chord"));
        EditorGUI.PropertyField(area = NewLine(area), _span, new GUIContent("Span"));
        EditorGUI.PropertyField(area = NewLine(area), _wingArea, new GUIContent("Total Area"));
        EditorGUI.PropertyField(area = NewLine(area), _controlSize, new GUIContent("Control Surface Size"));
        EditorGUI.PropertyField(area = NewLine(area), _aoa, new GUIContent("Angle of Attack"));
        EditorGUI.PropertyField(area = NewLine(area), _stallAngle, new GUIContent("Stall Angle"));
        EditorGUI.PropertyField(NewLine(area), _zeroLiftAngle, new GUIContent("Zero Lift Angle"));
    }
    
    private Rect NewLine(Rect rect)
    {
        rect.y += EditorGUIUtility.singleLineHeight;
        return rect;
    }
}