using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloor : MonoBehaviour {

    public PlayerControl PControl; //reference back to player control

    //collision check method
    private void OnTriggerStay2D(Collider2D col)
    {
        if (!col.gameObject.name.Contains("spike") && !col.gameObject.name.Contains("laser"))
        {
            PControl.onFloor = true;
        }
        Debug.Log("on floor");
    }
    
    //collision uncheck method
    private void OnTriggerExit2D(Collider2D col)
    {
        if (!col.gameObject.name.Contains("spike") && !col.gameObject.name.Contains("laser"))
            PControl.onFloor = false;
        Debug.Log("left floor");
    }
}
