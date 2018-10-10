using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowState : MonoBehaviour {

    public List<GameObject> ShadowList;

    public ActiveShadow activeShadow;
    public enum ActiveShadow
    {
        left,
        center,
        right
    }

	// Use this for initialization
	void Start () {
        activeShadow = ActiveShadow.right;
	}
	
	// Update state of shadows based on keys pressed
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            activeShadow = ActiveShadow.left;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            activeShadow = ActiveShadow.center;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            activeShadow = ActiveShadow.right;
        ValidateInput();
    }

    //validate player's input and change state
    void ValidateInput()
    {
        foreach(GameObject i in ShadowList)
        {
            if (i.name == ("shadow" + (int)activeShadow))
                i.SetActive(true);
            else
                i.SetActive(false);
        }
    }
}
