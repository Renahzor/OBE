using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType { Weapon, Armor, Consumable }

public class EquipmentItem : MonoBehaviour {

    public EquipmentType equipmentType { get; private set; }

    int minDamage;
    int maxDamage;
    int armorClass;

    int rarity;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
