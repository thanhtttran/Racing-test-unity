using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;//remove this when youre done testing
using UnityEngine;


public class miscdebug : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startingPosition;
    public Quaternion startingRotation;
    public Text timeStats;

    public GameObject camera;
    public Vector3 cameraPos;
    public Quaternion cameraRot;


    private float elapsedTime;
    void Start()
    {
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        cameraPos = camera.transform.position;
        cameraRot = camera.transform.rotation; 
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("resetted");
                Reset();
            }
        }
        timeStats.text = elapsedTime.ToString();
    }

    //reset location to start
    public void Reset()
    {
        transform.position = startingPosition;
        transform.rotation = startingRotation;
        camera.transform.position = cameraPos;
        camera.transform.rotation = cameraRot;  
    }
}
