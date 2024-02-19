using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType {Kg, Lbs}

[AddComponentMenu("AeroPyhsics/Airplane Body")]
public class AeroBody : MonoBehaviour
{
    [SerializeField] public bool _debugMode = false;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _weight;
    [SerializeField] private UnitType _unit;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _altitude;
    [SerializeField] private float _airDensity;
    [SerializeField] private AeroSurface[] _aeroSurfaces;
    [SerializeField] private AeroEngine[] _aeroEngines;
}
