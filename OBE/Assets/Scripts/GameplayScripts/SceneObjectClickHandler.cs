using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectClickHandler : MonoBehaviour {

    public void Clicked()
    {
        GameObject.Find("GameMaster").GetComponent<GameMaster>().SceneObjectClicked(gameObject);
    }

    public void RightClicked()
    {
        GameObject.Find("GameMaster").GetComponent<GameMaster>().SceneObjectRightClicked(gameObject);
        Debug.Log("RightClickRegistered");
    }
}
