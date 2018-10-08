using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    [SerializeField]
    private GameObject villagerPrefab;
    NameGenerator Names;

    [SerializeField]
    //starting number of villagers to spawn
    private int startingVillagers = 1; 

	// Use this for initialization
	void Start () {
        Names = this.gameObject.GetComponent<NameGenerator>();
        
        //spawns initial villagers with randomized gender and names.
        for (int i = 0; i < startingVillagers; i++)
        {
            bool gender = (Random.value > 0.5f); //gives us a random gender for name
            var newVillager = Instantiate(villagerPrefab) as GameObject;
            newVillager.GetComponent<VillagerScript>().SetName(Names.GetName(gender));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
