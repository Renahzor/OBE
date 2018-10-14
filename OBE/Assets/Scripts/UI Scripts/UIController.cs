using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    //Hold instances of each of the UI elements

    [SerializeField]
    private GameObject bottomLeftPanel;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ClickedNPC(GameObject npcClicked)
    {
        Text bottomLeftHeader = bottomLeftPanel.GetComponentInChildren<Text>();

        bottomLeftHeader.text = npcClicked.GetComponent<VillagerScript>().villagerName;
    }
}
