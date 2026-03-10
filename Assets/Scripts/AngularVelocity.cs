using UnityEngine;
using UnityEngine.InputSystem;

public class AngularVelocity : MonoBehaviour
{
    public int angularSpeed;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed) //if (Input.GetKeyDown(KeyCode.A))
        {
            rb.angularVelocity = new Vector3(0, angularSpeed, 0);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }
}
