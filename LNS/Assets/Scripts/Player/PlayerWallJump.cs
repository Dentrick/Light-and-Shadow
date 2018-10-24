using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : MonoBehaviour {

    public PlayerControl PControl; //reference back to player control

    //collision check method (enter walljump mode once)
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("WJ"))
        {
            PControl.velocity = 0;
            PControl.wallJumpReset = true; //reset walljump
        }
        Debug.Log("enter walljump mode");
    }
    
    //collision check method (enter walljump mode)
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("WJ"))
        {
            PControl.currMass = PControl.grabMass;
        }
        Debug.Log("in walljump mode");
    }
    
    //collision uncheck method (leave walljump mode)
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("WJ"))
        {
            PControl.currMass = PControl.mass;
            PControl.wallJumpReset = false; //disallow jump
        }
        Debug.Log("left walljump mode");
    }
}
