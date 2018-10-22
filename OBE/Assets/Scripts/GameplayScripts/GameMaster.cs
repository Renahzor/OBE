using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to control the overall gamestate and contain globals necessary for gameplay
public class GameMaster : MonoBehaviour {

    private int currency = 250;
    [SerializeField]
    private GameObject villagerPrefab;
    NameGenerator Names;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    private UIController uiController;

    [SerializeField]
    //starting number of villagers to spawn
    private int startingVillagers = 1; 

	// Use this for initialization
	void Start () {
        Names = this.gameObject.GetComponent<NameGenerator>();
        uiController.UpdateCurrencyDisplay(currency);
        
        //spawns initial villagers with randomized gender and names.
        for (int i = 0; i < startingVillagers; i++)
        {
            bool gender = (Random.value > 0.5f); //gives us a random gender for name selection
            var newVillager = Instantiate(villagerPrefab) as GameObject;
            newVillager.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
            newVillager.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            newVillager.GetComponent<VillagerScript>().SetName(Names.GetName(gender));
            newVillager.GetComponent<Transform>().position = new Vector3(Random.Range(-30.0f, 30.0f), 1.07f, Random.Range(-30.0f, 30.0f));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		//Get raycast for mouseclicks
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<SceneObjectClickHandler>() != null)
                {
                    hit.transform.GetComponent<SceneObjectClickHandler>().Clicked();
                }
            }
        }

        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<SceneObjectClickHandler>() != null)
                {
                    hit.transform.GetComponent<SceneObjectClickHandler>().RightClicked();
                }
            }
        }


    }

    //Using GameMaster as the main handler to pass scene clicked items to the UI
    public void SceneObjectClicked(GameObject itemClicked)
    {
        if (itemClicked.GetComponent<VillagerScript>() || itemClicked.GetComponent<Structure>())
        {
            uiController.GetComponent<UIController>().ObjectClicked(itemClicked);
        }
    }

    public void SceneObjectRightClicked(GameObject itemClicked)
    {
        if (itemClicked.GetComponent<Structure>() && uiController.GetComponent<UIController>().selectedVillager != null)
        {
            itemClicked.GetComponent<Workshop>().AssignVillagerToWork(uiController.GetComponent<UIController>().selectedVillager.GetComponent<VillagerScript>());
            uiController.GetComponent<UIController>().ObjectClicked(itemClicked);
        }
            
    }
}
