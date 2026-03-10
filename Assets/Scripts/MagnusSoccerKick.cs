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
            if (Keyboard.current.aKey.isPressed)
            {
                isShot = true;
                rb.AddForce(LeftCurve(kickForce), ForceMode.Impulse);
                rb.AddTorque(LeftSpin(spinAmount));
            }
            else if (Keyboard.current.dKey.isPressed)
            {
                isShot = true;
                rb.AddForce(RightCurve(kickForce), ForceMode.Impulse);
                rb.AddTorque(RightSpin(spinAmount));
            }
            else
            {
                Debug.Log("Error, Hold A or D");
            }
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

    public Vector3 LeftCurve(float kickForce)
    {
        return new Vector3(-1, 0, 1) * kickForce;
    }

    public Vector3 RightCurve(float kickForce)
    {
        return new Vector3(1, 0, 1) * kickForce;
    }

    public Vector3 LeftSpin(float spinAmount)
    {
        return spinAmount * new Vector3(-1, 1, 0);
    }

    public Vector3 RightSpin(float spinAmount)
    {
        return spinAmount * new Vector3(1, 1, 0);
    }
}
