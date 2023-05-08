using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class simpleAnimation : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 2.0f;
    private Vector3 initialPosition;

    public float rotationAmount = 30f;


    // Start is called before the first frame update
    void Start()
    {
       initialPosition = transform.parent.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //give sphere breathing up and down pattern
        float newY = initialPosition.y + amplitude * Mathf.Sin(Time.time * 2 * Mathf.PI * frequency);

        // Update the GameObject's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        //transform.rotation = Quaternion.Euler(0, 1, 0);
    }
}
