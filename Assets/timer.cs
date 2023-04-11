using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    private float elapsedTime;
    private bool isTiming;
    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTiming)
        {
            elapsedTime = Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        isTiming = true;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
    }

    public float GetElapsedtime()
    {
        return elapsedTime;
    }
}
