using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerScript : MonoBehaviour {

    private Profession profession;
    [SerializeField]
    private Stats stats;

    [SerializeField]
    private string villagerName;

    private HealthScript health;

	// Use this for initialization
	void Start () {
        stats = new Stats();
        health = new HealthScript(stats.Toughness, 1);
        profession = new Profession(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetName(string s)
    {
        villagerName = s;
    }

}
