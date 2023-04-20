using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin2d : MonoBehaviour
{
    float curRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curRotation += Time.deltaTime * 100f;


        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.rotation = Quaternion.Euler(0, curRotation, 0);
    }
}
