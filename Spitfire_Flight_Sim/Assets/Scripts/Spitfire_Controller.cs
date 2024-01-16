using UnityEngine;

public class Spitfire_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float AoA;
    [SerializeField] private float horsePower;
    [SerializeField] private float throttle;
    [SerializeField] private float weight;
    [SerializeField] private Vector3 localVelocity;
    [SerializeField] private Vector3 localAngularVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = weight / Physics.gravity.y;
    }

    void Update()
    {

    }
}
