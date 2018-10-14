using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float cameraMoveSpeed;
    [SerializeField]
    private float zoomSpeed;
    [SerializeField]
    private float rotationSpeed;

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

        if (Input.GetKey(KeyCode.W))
        {
            var panDirection = transform.forward;
            panDirection.y = 0;
            panDirection.Normalize();
            transform.Translate(panDirection * Time.deltaTime * cameraMoveSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            var panDirection = transform.forward;
            panDirection.y = 0;
            panDirection.Normalize();
            transform.Translate(panDirection * Time.deltaTime * -cameraMoveSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            var panDirection = transform.right;
            panDirection.y = 0;
            panDirection.Normalize();
            transform.Translate(panDirection * Time.deltaTime * -cameraMoveSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            var panDirection = transform.right;
            panDirection.y = 0;
            panDirection.Normalize();
            transform.Translate(panDirection * Time.deltaTime * cameraMoveSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(cameraFocusPoint.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(cameraFocusPoint.transform.position, Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        //Zoom Camera with scroll wheel, cheks extents and scroll direction, then zooms camera relative to focal point.
        if ( (Vector3.Distance(transform.position, cameraFocusPoint.transform.position) > zoomMin && mouseWheel > 0.0f) ||
             (Vector3.Distance(transform.position, cameraFocusPoint.transform.position) < zoomMax && mouseWheel < 0.0f) )
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, cameraFocusPoint.transform.position, mouseWheel * Time.deltaTime * zoomSpeed);
	}
}
