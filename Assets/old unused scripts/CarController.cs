using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float acceleration = 10f;
    public float steer = 5f;
    public Text stats;

    Rigidbody myrb;
    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 force = transform.forward * vertical * acceleration;
        myrb.AddForce(force);

        float speed = myrb.velocity.magnitude;
        //float rotationMultiplier = Mathf.Lerp(1f, 0.5f, speed/20f);
        float rotation = horizontal * steer; //*rotationMultiplier;
        myrb.AddTorque(transform.up * rotation);

        //update stats for debug
        stats.text = rotation.ToString() + "bomb" + speed.ToString();
    }
}
