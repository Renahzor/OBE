using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerScript : MonoBehaviour {

    private Profession profession;
    [SerializeField]
    private Stats stats;

    [SerializeField]
    private string villagerName;

	// Use this for initialization
	void Start () {
        stats = new Stats();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetName(string s)
    {
        villagerName = s;
    }

}
