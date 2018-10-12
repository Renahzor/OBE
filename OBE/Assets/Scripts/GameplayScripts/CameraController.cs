using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float cameraMoveSpeed;
    [SerializeField]
    private float zoomSpeed;

    private float zoomMax;
    private float zoomMin;

    [SerializeField]
    GameObject cameraFocusPoint;

	// Use this for initialization
	void Start ()
    {
        zoomMax = 50.0f;
        zoomMin = 15.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //set camera focus for zoom.
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 100))
        {
            cameraFocusPoint.transform.position = hitInfo.point;
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -cameraMoveSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * -cameraMoveSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed, Space.World);
        }

        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        //Zoom Camera with scroll wheel, cheks extents and scroll direction, then zooms camera relative to focal point.
        if ( (Vector3.Distance(transform.position, cameraFocusPoint.transform.position) > zoomMin && mouseWheel > 0.0f) ||
             (Vector3.Distance(transform.position, cameraFocusPoint.transform.position) < zoomMax && mouseWheel < 0.0f) )
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, cameraFocusPoint.transform.position, mouseWheel * Time.deltaTime * zoomSpeed);
        
	}
}
