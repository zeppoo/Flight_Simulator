using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AeroSurface", menuName = "AeroSurface")]
public class AeroSurface : ScriptableObject
{
    [SerializeField] private Vector2 surfaceSize;
    [SerializeField] private float flapsSize;
    [SerializeField] private AnimationCurve liftSlope;
    public Vector3 normal = Vector3.up;
    public float size = 1f;
}
