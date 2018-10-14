using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClickHandler : MonoBehaviour {

    public void Clicked()
    {
        Debug.Log("Clicked " + gameObject.GetComponent<VillagerScript>().villagerName);

        GameObject.Find("GameMaster").GetComponent<GameMaster>().SceneObjectClicked(gameObject);
    }
}
