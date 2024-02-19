using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EngineType {Propeller, Jet}

[System.Serializable]
public class AeroEngine
{
    [SerializeField] private EngineType _engineType = EngineType.Propeller;
    [SerializeField] private Vector3 _position = Vector3.zero;
    [SerializeField] private Vector3 _direction = Vector3.forward;
    [SerializeField] private float _thrust = 0;
    [SerializeField] private int _throttle = 0;
    [SerializeField] private float _efficiency = 0;
    [SerializeField] private float _impulse = 0;
    [SerializeField] private float _rps = 0;
    [SerializeField] private float _diameter = 0;
    [SerializeField] private float _thrustCo = 0;
    [SerializeField] private float _inletWidth = 1;
    [SerializeField] private float _inletHeight = 1;
}
