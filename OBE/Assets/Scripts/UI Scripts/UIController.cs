using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Class to handle UI panels, information, and display. */
public class UIController : MonoBehaviour {

    //Hold instances of each of the main UI panels
    [SerializeField]
    private GameObject villagerPanel;
    [SerializeField]
    private GameObject buildPanel;
    [SerializeField]
    private GameObject statsTextElement;
    [SerializeField]
    private GameObject buildButtonPrefab;

	// Use this for initialization
	void Start ()
    {
        villagerPanel.SetActive(false);
        SetupBuildPanel();
	}
	
    //Takes a scene object that was clicked and populates the appropriate UI elements with the info needed.
    public void ObjectClicked(GameObject objectClicked)
    {
        //check attached scripts to find what type of object has been clicked, activate and populate appropriate UI elements
        if (objectClicked.GetComponent<VillagerScript>())
        {
            VillagerScript v = objectClicked.GetComponent<VillagerScript>();
            villagerPanel.SetActive(true);
            var villagerPanelTextElements = villagerPanel.GetComponentsInChildren<Text>();

            //set all of our text elements
            foreach (Text t in villagerPanelTextElements)
            {
                if (t.name == "Header")
                    t.text = v.villagerName;
                else if (t.name == "HP")
                    t.text = "HP: " + v.health.currentHP + " / " + v.health.maxHP;
                else if (t.name == "ProfessionText")
                    t.text = "Level " + v.prof.level + " " + v.prof.profession + "   " + v.prof.experiencePoints + " / " + v.prof.experienceToLevel + " exp";
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

                element.GetComponent<Text>().text = stat.Key + " " + stat.Value;
            }
        }
    }

    public void ClosePanel(GameObject panelToClose)
    {
        panelToClose.SetActive(false);
    }

    //Method for populating the build windows
    private void SetupBuildPanel()
    {

    }
}
