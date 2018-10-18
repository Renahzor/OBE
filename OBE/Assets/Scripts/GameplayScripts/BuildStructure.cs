using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStructure : MonoBehaviour {

    [SerializeField]
    private List<GameObject> structurePrefabs;

    GameObject newBuilding = null;
    bool placingObject = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (placingObject && newBuilding != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Terrain")))
                newBuilding.transform.position = new Vector3(hit.point.x, newBuilding.transform.position.y, hit.point.z);

            if (Input.GetMouseButtonDown(0))
            {
                placingObject = false;
                newBuilding = null;
            }
        }
	}

    public void StartBuild(int prefabIndex)
    {
        newBuilding = Instantiate(structurePrefabs[prefabIndex]);
        placingObject = true;
    }
}
