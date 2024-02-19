using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlType{None, flap, aeleron, ruli, rudder}

[System.Serializable]
public class AeroSurface
{
    [SerializeField] private ControlType _controlType;
    [SerializeField] private float _lift;
    [SerializeField] private float _chord = 1;
    [SerializeField] private float _span = 1;
    [SerializeField] private float _wingArea;
    [SerializeField] private float _controlSize = 1;
    [SerializeField] private float _aoa;
    [SerializeField] private float _stallAngle;
    [SerializeField] private float _zeroLiftAngle;
}
