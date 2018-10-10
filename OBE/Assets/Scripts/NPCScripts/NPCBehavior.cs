using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to decide what an NPC should be doing at any given time.

public class NPCBehavior : MonoBehaviour {

    enum TaskTypes { Idle, MoveToLocation, Work, FindQuest }

    TaskTypes currentTask = TaskTypes.Idle;

    public bool assigned { get; private set; }

	// Use this for initialization
	void Start () {
        assigned = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void AssignTask()
    {

    }
}
