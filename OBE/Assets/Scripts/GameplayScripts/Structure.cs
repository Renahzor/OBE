using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public string structureName { get; private set; }

    int upgradeLevel;
    float actionTime;
    float upgradeTimer;

    private GameObject modelPrefab;
    private GameObject navPoint;

    public void Upgrade()
    {
        
    }
}

//Workshops require a profession, and create items for sale, both at the workshop and for sale at stalls
public class Workshop : Structure
{
    public enum WorkshopType { Blacksmith, Apothecary, Scribe, Tannery, Bowery, Brewery }

    public WorkshopType workshopType { get; private set; }

    Professions professionRequired;
}

//Inns and other gathering places for social interaction, sleep, and drink
public class Inn : Structure
{
    public enum InnType { Tavern, Public_House, Lodge, Inn }

    public InnType innType { get; private set; }

    int PatronsAllowed;
    int numberOfBeds;
    int bedQuality;
}

//Stalls buy and sell goods, both made from workshops and collected from questing
public class Stall : Structure
{
    public enum StallType { Potions, Outfitter, Weapons, Armor, Magic  }

    public StallType stallType { get; private set; }

}

public class Laboratory : Structure
{

}
