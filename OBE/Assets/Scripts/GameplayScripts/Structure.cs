using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public string structureName;

    public int upgradeLevel { get; protected set; }
    protected float actionTime;
    protected float upgradeTimer;

    protected GameObject buildingModel;
    protected GameObject navPoint;

    public virtual void Upgrade()
    {
        
    }
}

//Workshops require a profession, and create items for sale, both at the workshop and for sale at stalls
public enum WorkshopType { Blacksmith, Apothecary, Scribe, Tannery, Bowery, Brewery }
public class Workshop : Structure
{
    public Professions requiredProfession;

    public WorkshopType workshopType { get; private set; }

    public List<VillagerScript> villagersWorkingHere { get; private set; }
    public List<EquipmentItem> itemsCraftable { get; private set; }

    public int numberOfWorkersAllowed { get; private set; }


    public void SetupWorkshop(WorkshopType type, string buildingName, int level, GameObject model, GameObject navigationPoint, Professions reqProfession)
    {
        workshopType = type;
        structureName = buildingName;
        upgradeLevel = level;
        buildingModel = model;
        navPoint = navigationPoint;
        numberOfWorkersAllowed = 1;
        requiredProfession = reqProfession;

        villagersWorkingHere = new List<VillagerScript>();
        itemsCraftable = new List<EquipmentItem>();

        Debug.Log("Setup Completed");
    }

    public void AssignVillagerToWork(VillagerScript villager)
    {
        if (!villagersWorkingHere.Contains(villager) && numberOfWorkersAllowed > villagersWorkingHere.Count)
        {
            villagersWorkingHere.Add(villager);
            Debug.Log("Villager Added to building" + villager.villagerName);
            villager.SetDestination(this.transform.Find("NavPoint").gameObject);
        }
    }
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
