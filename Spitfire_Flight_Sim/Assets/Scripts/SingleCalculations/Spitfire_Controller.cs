using Unity.VisualScripting;
using UnityEngine;

public class Spitfire_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float AoA;
    [SerializeField] private float horsePower;
    [SerializeField] private float throttle;
    [SerializeField] private float weight;
    [SerializeField] private float rollForce;
    [SerializeField] private float yawForce;
    [SerializeField] private float pitchForce;
    [Range(0f, 0.2f)][SerializeField] private float liftChange;
    [SerializeField] private Vector3 localVelocity;
    [SerializeField] private Vector3 localAngularVelocity;
    [SerializeField] private Vector3 InputField;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = weight / -Physics.gravity.y;
    }

    void Update()
    {
        InputField = GetInput();
        UpdateVelocity();
        ApplyPhysics();
    }

    private void UpdateVelocity()
    {
        localVelocity = transform.InverseTransformDirection(rb.velocity);
        localAngularVelocity = transform.InverseTransformDirection(rb.angularVelocity);
    }

    private void ApplyPhysics()
    {
        AoA = PlanePhysics.GetAoA(localVelocity);
        //Apply Thrust
        rb.AddRelativeForce(PlanePhysics.GetThrust(throttle, horsePower) * Time.deltaTime);
        rb.AddRelativeForce(PlanePhysics.GetLift(localVelocity, PlanePhysics.GetLiftCoefficient(AoA, liftChange)) * Time.deltaTime);
    }

    private Vector3 GetInput()
    {
        throttle += Input.GetAxis("Mouse ScrollWheel") * 10f;
        throttle = Mathf.Clamp(throttle, 0, 100);
        return new Vector3(Input.GetAxis("Pitch"), Input.GetAxis("Yaw"), Input.GetAxis("Roll"));
    }
}
