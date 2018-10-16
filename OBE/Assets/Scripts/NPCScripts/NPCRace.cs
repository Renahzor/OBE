using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Race { Human, Dwarf, Elf, Halfling, Gnome, Half_Elf }

public class NPCRace : MonoBehaviour {

    public Race race { get; private set; }

	// Use this for initialization
	void Start ()
    {
        Race race = (Race)Random.Range(0, 6);

        switch (race)
        {
            case Race.Dwarf:
                transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                break;

            case Race.Halfling:
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;

            case Race.Gnome:
                transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                break;

            default: break;                
        }
	}
	
}
