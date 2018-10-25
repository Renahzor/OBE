using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Class to handle UI panels, information, and display. */
public class UIController : MonoBehaviour {

    public GameObject selectedVillager { get; private set; }

    //Hold instances of each of the main UI panels
    [SerializeField]
    private GameObject villagerPanel;
    [SerializeField]
    private GameObject buildPanel;
    [SerializeField]
    private GameObject statsTextElement;
    [SerializeField]
    private GameObject buildButtonPrefab;
    [SerializeField]
    private Text currencyDisplay;
    [SerializeField]
    private Text selectedVillagerText;

    //Structure UI panel elements
    [SerializeField]
    private GameObject structurePanel;
    [SerializeField]
    private GameObject structureTextElementPrefab;

	// Use this for initialization
	void Start ()
    {
        selectedVillager = null;
        villagerPanel.SetActive(false);
        SetupBuildPanel();
	}
	
    //Takes a scene object that was clicked and populates the appropriate UI elements with the info needed.
    public void ObjectClicked(GameObject objectClicked)
    {
        //check attached scripts to find what type of object has been clicked, activate and populate appropriate UI elements
        if (objectClicked.GetComponent<VillagerScript>())
        {
            if (selectedVillager != null)
            {
                selectedVillager.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
            }

            selectedVillager = objectClicked;
            selectedVillager.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            VillagerScript v = objectClicked.GetComponent<VillagerScript>();
            villagerPanel.SetActive(true);
            var villagerPanelTextElements = villagerPanel.GetComponentsInChildren<Text>();

            if (selectedVillager == null)
                selectedVillagerText.text = "No Villager Selected";

            else
                selectedVillagerText.text = "Selected Villager: " + v.villagerName;

            //set all of our text elements
            foreach (Text t in villagerPanelTextElements)
            {
                if (t.name == "Header")
                    t.text = v.villagerName;
                else if (t.name == "HP")
                    t.text = "HP: " + v.health.currentHP + " / " + v.health.maxHP;
                else if (t.name == "ProfessionText")
                    t.text = "Level " + v.prof.professionLevels[v.prof.assignedProfession] + " " + v.prof.assignedProfession;
            }

            //get the stats panel
            var statsPanel = villagerPanel.transform.Find("StatsPanel");

            //clear stats panel
            foreach (Transform child in statsPanel)
                GameObject.Destroy(child.gameObject);
            
            //populate stats panel
            foreach (KeyValuePair<string, int> stat in v.stats.StatsList)
            {
                var element = Instantiate(statsTextElement);
                element.transform.SetParent(statsPanel, false);
                element.GetComponent<Text>().fontSize = 14;
                element.GetComponent<Text>().fontStyle = FontStyle.Bold;
                element.GetComponent<Text>().text = stat.Key + " " + stat.Value;
            }

            foreach (KeyValuePair<Professions, int> professionStat in v.prof.professionLevels)
            {
                var element = Instantiate(statsTextElement);
                element.transform.SetParent(statsPanel, false);

                element.GetComponent<Text>().text = professionStat.Key.ToString() + " " + professionStat.Value;
            }
        }

        //Workshop UI display
        if (objectClicked.GetComponent<Workshop>())
        {
            Workshop s = objectClicked.GetComponent<Workshop>();
            structurePanel.SetActive(true);

            var structurePanelTextElements = structurePanel.GetComponentsInChildren<Text>();

            foreach (Text t in structurePanelTextElements)
            {
                if (t.name == "Header")
                    t.text = s.structureName;
                if (t.name == "LevelDisplay")
                    t.text = "Lvl " + s.upgradeLevel + " Workshop";
            }

            var structureTextPanel = structurePanel.transform.Find("StructureInfoPanel");
            foreach (Transform child in structureTextPanel)
            {
                Destroy(child.gameObject);
            }

            var element = Instantiate(structureTextElementPrefab);
            element.transform.SetParent(structureTextPanel, false);
            element.GetComponent<Text>().text = "Workers: " + s.villagersWorkingHere.Count + "/" + s.numberOfWorkersAllowed;

            element = Instantiate(structureTextElementPrefab);
            element.transform.SetParent(structureTextPanel, false);
            element.GetComponent<Text>().text = "Level: " + s.upgradeLevel;
        }
    }

    public void ClosePanel(GameObject panelToClose)
    {
        panelToClose.SetActive(false);
    }

    //Method for populating the build windows
    private void SetupBuildPanel()
    {
        foreach (var buildingType in Enum.GetValues(typeof(WorkshopType)))
        {
            var newButton = Instantiate(buildButtonPrefab);
            newButton.transform.SetParent(buildPanel.transform, false);
            newButton.GetComponentInChildren<Text>().text = buildingType.ToString();
            newButton.GetComponent<Button>().onClick.AddListener( () => { GameObject.Find("GameMaster").GetComponent<BuildStructure>().StartBuild((int)buildingType); } );
        }
    }

    public void UpdateCurrencyDisplay(int quantity)
    {
        currencyDisplay.text = "Gold: " + quantity;
    }
}
