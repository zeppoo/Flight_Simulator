using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class PlanePhysics
{
    public static float GetAoA(Vector3 lv)
    {
        float AoA = Vector3.Angle(lv, Vector3.forward);
        return AoA;
    }

    public static Vector3 GetThrust(float throttle, float horsePower)
    {
        Vector3 thrust = throttle * horsePower * Vector3.forward;
        return thrust;
    }

    public static float GetLiftCoefficient(float AoA, float LCS)
    {
        float LiftCo = 0 + LCS * AoA;
        return LiftCo;
    }

    public static Vector3 GetLift(Vector3 lv, float lc)
    {
        float velocitySquared = lv.sqrMagnitude;
        Vector3 liftForce = 0.5f * lc * velocitySquared * Vector3.up;
        return liftForce;
    }


}
