using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public string structureName;

    [SerializeField]
    private int upgradeLevel;
    [SerializeField]
    private float actionTime;
    [SerializeField]
    private float upgradeTimer;

    [SerializeField]
    private GameObject modelPrefab;
    //NavPoint should be near the entrance door for pathfinding.
    [SerializeField]
    private GameObject navPoint;

    public virtual void Upgrade()
    {
        
    }
}

//Workshops require a profession, and create items for sale, both at the workshop and for sale at stalls
public enum WorkshopType { Blacksmith, Apothecary, Scribe, Tannery, Bowery, Brewery }
public class Workshop : Structure
{
    public WorkshopType workshopType { get; private set; }

    Professions professionRequired;
}

//Inns and other gathering places for social interaction, sleep, and drink
public enum InnType { Tavern, Public_House, Lodge, Inn }
public class Inn : Structure
{
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
