using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Vector3 currentDestination;

    [SerializeField]
    private int speed;

	// Use this for initialization
	void Start () {
        SetDestination(GameObject.Find("TestCube"));
	}
	
	// Update is called once per frame
	void Update () {

        if (currentDestination != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, (speed * Time.deltaTime));
        }
        

	}

    public void SetDestination(GameObject destination)
    {
        currentDestination = destination.transform.localPosition;
        currentDestination.y = 1;
    }
}
