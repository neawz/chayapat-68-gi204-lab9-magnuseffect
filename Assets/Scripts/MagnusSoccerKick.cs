using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusSoccerKick : MonoBehaviour
{
    public float kickForce;
    public float spinAmount;
    public float magnusStrength;

    Rigidbody rb;
    bool isShot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isShot)
        {
            isShot = true;
            rb.AddForce(new Vector3(-1, 0, 1) * kickForce, ForceMode.Impulse);
            rb.AddTorque(spinAmount * new Vector3(-1, 1, 0));
        }
    }

    private void FixedUpdate()
    {
        if (!isShot) return;

        Vector3 velocity = rb.linearVelocity;
        Vector3 spin = rb.angularVelocity;
        rb.AddForce(MagnusForce(spin, velocity));
    }

    public Vector3 MagnusForce(Vector3 spin, Vector3 velocity)
    {
        return magnusStrength * Vector3.Cross(spin, velocity);
    }
}
