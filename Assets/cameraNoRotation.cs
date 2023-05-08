using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class cameraNoRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = transform.rotation;
        //make it such that the focus does not rotate in z 
        Quaternion desiredRotation = Quaternion.Euler(0,currentRotation.eulerAngles.y, 0);
        //lerp it for smooth
        transform.rotation = Quaternion.Lerp(currentRotation, desiredRotation, 0.05f);
    }
}
