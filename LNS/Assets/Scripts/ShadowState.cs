using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowState : MonoBehaviour {

    public List<GameObject> ShadowList; //list of shadows under this block
    public PlayerControl pControl; //player control (for referencing)

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
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            activeShadow = ActiveShadow.left;
            IsOnFloorCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            activeShadow = ActiveShadow.center;
            IsOnFloorCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            activeShadow = ActiveShadow.right;
            IsOnFloorCheck();
        }
            
        ValidateInput();
    }

    //validate player's input and change state
    void ValidateInput()
    {
        foreach(GameObject i in ShadowList)
        {
            if (i.name == ("shadow" + (int)activeShadow) || i.name == ("laser" + (int)activeShadow))
                i.SetActive(true);
            else
                i.SetActive(false);
        }
    }

    //controlled try catch of pControl
    void IsOnFloorCheck()
    {
        try
        {
            pControl.onFloor = false;
        }
        catch { }
    }
}
