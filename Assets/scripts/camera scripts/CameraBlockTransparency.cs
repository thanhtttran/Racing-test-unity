using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class CameraBlockTransparency : MonoBehaviour
{
    public Material transparentMaterial;
    public float raycastDistance = 5f;

    private GameObject blockingObject;
    private Material blockingObjectMaterial;

    private Camera myCam;
    // Start is called before the first frame update
    void Start()
    {
        myCam= GetComponent<Camera>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        //raycast straight forward
        RaycastHit hitInfo;
        bool isBlocked = Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hitInfo, raycastDistance);
        Debug.DrawRay(myCam.transform.position, myCam.transform.forward * raycastDistance, Color.green);

        if (isBlocked)
        {
            //store the original materials
            blockingObject = hitInfo.transform.gameObject;
            Renderer hitRenderer = blockingObject.GetComponent<Renderer>();
            blockingObjectMaterial = hitRenderer.GetComponent<Material>();

            
            Debug.Log("blocked by: " + blockingObject.name.ToString());

        //    if (hitRenderer != null)
        //    {
        //        hitRenderer.material = transparentMaterial;
        //    }
        //}
        //else
        //{
        //    if (blockingObject != null)
        //    {
        //        Renderer hitRenderer = blockingObject.GetComponent<Renderer>();
        //        if (hitRenderer != null)
        //        {
        //            hitRenderer.material = blockingObjectMaterial;
        //        }
        //    }
        }

    }
}
