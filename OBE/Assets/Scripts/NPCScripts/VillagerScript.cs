﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerScript : MonoBehaviour {

    public ProfessionScript prof { get; private set; }
    public Stats stats { get; private set; }

    public string villagerName { get; private set; }
    public HealthScript health { get; private set; }
    private Movement movement;

    public NPCRace race;

    private NPCNeeds npcNeeds;
	// Use this for initialization
	void Start ()
    {
        movement = gameObject.GetComponent<Movement>();
        stats = new Stats();
        prof = new ProfessionScript(1, stats);
        health = new HealthScript(stats.StatsList["Toughness"], 1, prof.assignedProfession);

        npcNeeds = new NPCNeeds(prof.assignedProfession, stats);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetName(string s)
    {
        villagerName = s;
    }

    public void SetDestination(GameObject destination)
    {
        movement.SetDestination(destination);
    }
}
