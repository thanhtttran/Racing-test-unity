using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine.UI;//remove this when youre done testing
using UnityEngine;
using UnityEditor.VersionControl;
using Unity.VisualScripting;

public class raycastcartest : MonoBehaviour
{
    public float force = 10f;
    public float raycastDistance = 1.3f;
    public LayerMask groundLayer;
    //wheels bstuff
    public Transform[] wheelTransforms;
    //might have to expand on this
    public float wheelDistance = 1f;
    public float damping = 1f;

    public float acceleration = 5f;
    public float maxSpeed = 30f;

    //steering stuff
    public float tireGripFactor = 1f;
    public float tireMass = 1f;
    public float maxSteeringAngle = 30f;

    public float brakingForceMagnitude = 0.5f;
    public float brakingForceVelFactor = 0.5f;
    //private bool isBraking = false;
    //public GameObject trackmarkPrefab;

    public float nitroForce = 100f;

    private Rigidbody myrb;
    private RaycastHit hitInfo;

    public Text stats;
    public GameObject pointer;
    public GameObject wheel;

    //wheels prefab here
    //public GameObject wheelsPrefab;

    public AnnounceController announceController;

    private void Awake()
    {
        announceController.typeMessage("Hello, let's get racing!");
        myrb = GetComponent<Rigidbody>();

        Vector3 dummypos = myrb.transform.position;
        wheelTransforms = new Transform[4];

        //note to remove gameobject from this, unecessary
        //rear left
        wheelTransforms[0] = CreateWheelTransform(dummypos + new Vector3(-wheelDistance, 0f, -wheelDistance), "wheel1");
        //rear right
        wheelTransforms[1] = CreateWheelTransform(dummypos + new Vector3(wheelDistance, 0f, -wheelDistance), "wheel2");
        //front left
        wheelTransforms[2] = CreateWheelTransform(dummypos + new Vector3(-wheelDistance, 0f, wheelDistance), "wheel3");
        //front right
        wheelTransforms[3] = CreateWheelTransform(dummypos + new Vector3(wheelDistance, 0f, wheelDistance), "wheel4");
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(myrb.position, myrb.transform.forward, Color.blue, 1.0f);
        foreach (Transform t in wheelTransforms)
        {
            bool hitGround = Physics.Raycast(t.position, Vector3.down, out hitInfo, raycastDistance, groundLayer);
            if (hitGround)
            {
                //==============================================================================
                //calculate compression / suspension here,
                //find distance that the spring has compressed)
                float compression = (raycastDistance - hitInfo.distance) / raycastDistance;
                //find the force magnitude physics magic yada yada
                float forceMagnitude = compression * force;

                //remember to add damping force
                //this makes the suspension not act up all the time since suspension WANTS to be in one place at its best, 
                //in cars theres like fluid and piston that damp the springs i think


                //velocity alreayd exist here , use this one 
                Vector3 vel = myrb.GetPointVelocity(t.position);
                //more magic haha
                float dampingMagnitude = -damping * Vector3.Dot(vel, t.up);

                Vector3 totalF = (forceMagnitude + dampingMagnitude) * t.up;
                //Debug.Log(totalF);
                myrb.AddForceAtPosition(totalF, t.position, ForceMode.Acceleration);

                //==============================================================================
                //braking
                //make braking relative to the velocity
                if (Input.GetKey(KeyCode.Space))
                {
                    //Vector3 velocity = myrb.velocity;
                    Vector3 brakeForce = -vel.normalized * (brakingForceMagnitude + (vel.magnitude * brakingForceVelFactor));
                    myrb.AddForceAtPosition(brakeForce, t.position, ForceMode.Acceleration);
                    Debug.Log("braking" + brakeForce.ToString());

                    //debug brake ray
                    Debug.DrawRay(t.position, brakeForce, Color.blue, 1.5f);
                    announceController.typeMessage("Braking!");
                }


                //==============================================================================
                //nitro
                //if (Input.GetKeyDown(KeyCode.LeftShift))
                //{
                //    Debug.Log("using nitro");
                //    myrb.AddForce(myrb.transform.forward * nitroForce);

                //    //debug nitro ray
                //    Debug.DrawRay(myrb.position, myrb.transform.forward * nitroForce, Color.blue, 1.0f);
                //}

                //==============================================================================
                //running
                float vertical = Input.GetAxis("Vertical");
                Vector3 run = myrb.transform.forward * vertical * acceleration;
                if (vel.magnitude < maxSpeed)
                {
                    myrb.AddForceAtPosition(run, t.position, ForceMode.Acceleration);
                }
                if (vel.magnitude > maxSpeed)
                {
                    announceController.typeMessage("Whoa, Slow down!");
                }


                //==============================================================================
                //rotation
                //code from the internet because I cant understand physics at all
                Vector3 steeringDir = t.right;
                Vector3 tireWorldVel = myrb.GetPointVelocity(t.position);
                float steeringVel = Vector3.Dot(steeringDir, tireWorldVel);
                float desiredVelChange = -steeringVel * tireGripFactor;
                float desiredAccel = desiredVelChange / Time.fixedDeltaTime;
                myrb.AddForceAtPosition(steeringDir * desiredAccel * tireMass, t.position);
            }
            Debug.DrawRay(t.position, Vector3.down * raycastDistance, hitGround ? Color.green : Color.red);
        }

        for (int i = 2; i <= 3; i++)
        {
            Transform t = wheelTransforms[i];
            float horizontal = Input.GetAxis("Horizontal");
            float desiredSteeringAngle = Mathf.Clamp(horizontal * maxSteeringAngle, -maxSteeringAngle, maxSteeringAngle);
            //Debug.Log(desiredSteeringAngle);
            t.localRotation = Quaternion.Euler(0, desiredSteeringAngle, 0);
            wheel.transform.rotation = Quaternion.Euler(0, 0, -desiredSteeringAngle);
            Debug.DrawRay(t.position, t.forward, Color.yellow);
        }


        //update stats for debug
        stats.text = myrb.velocity.magnitude.ToString();
        float pointerAngle = myrb.velocity.magnitude * -180f / 20;
        //Debug.Log($"{pointerAngle}");
        pointer.transform.rotation = Quaternion.Euler(0, 0, pointerAngle);

    }


    //create gameobject wheels
    private Transform CreateWheelTransform(Vector3 position, String name)
    {
        GameObject wheelObject = new GameObject(name);
        wheelObject.transform.position = position;
        wheelObject.transform.parent = transform;
        return wheelObject.transform;
    }

    //handle vehicle crash here
    //check for velocity magnitude?
    //I also want the vehicle to morph when crashed, but maybe have to subdivide the model
    //also notify announcerController to type out message reactions

    //maybe a rumble material shader actually that stabilize after a bit
    void OnCollisionEnter(Collision collision)
    {
        int whatToSay = (int)UnityEngine.Random.Range(0, 2);
        switch (whatToSay)
        {
            case 0:
                announceController.typeMessage("Drive the car carefully!");
                break;
            case 1:
                announceController.typeMessage("Stop crashing you doofus!");
                break;
            case 2:
                announceController.typeMessage("You are breaking the car!");
                break;
        }

    }
}
