using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Vector3 currentDestination;

    [SerializeField]
    private int speed;

	// Use this for initialization
	void Start () {
        SetDestination(GameObject.Find("NavPoint"));
	}
	
	// Update is called once per frame
	void Update () {

        if (currentDestination != null)
        {
            currentDestination = new Vector3(currentDestination.x, transform.position.y, currentDestination.z);
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, (speed * Time.deltaTime));
        }
        

	}

    public void SetDestination(GameObject destination)
    {
        currentDestination = destination.transform.position;
    }
}
