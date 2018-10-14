using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerScript : MonoBehaviour {

    private Profession profession;
    public Stats stats { get; private set; }

    public string villagerName { get; private set; }
    public HealthScript health { get; private set; }
    private Movement movement;

	// Use this for initialization
	void Start ()
    {
        movement = gameObject.GetComponent<Movement>();
        stats = new Stats();
        health = new HealthScript(stats.StatsList["Toughness"], 1);
        profession = new Profession(1);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetName(string s)
    {
        villagerName = s;
    }
}
