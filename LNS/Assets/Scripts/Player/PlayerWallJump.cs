using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : MonoBehaviour {

    public PlayerControl PControl; //reference back to player control
    public float coyoteTime = 0.1f;
    float coyoteTimer;

    //setup coyote timer
    private void Start()
    {
        coyoteTimer = coyoteTime * 2; //initial state for ignore
    }

    //coyote timer
    void Update()
    {
        if (coyoteTimer != coyoteTime * 2 && coyoteTimer >= 0) //do nothing normally, decrease coyote timer else
            coyoteTimer -= Time.deltaTime;
        else if (coyoteTimer < 0)
        {
            PControl.onFloor = false;
            coyoteTimer = coyoteTime * 2; //something impossible normally to give an escape
        }
    }

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
            coyoteTimer = coyoteTime; //disallow jump
        }
        Debug.Log("left walljump mode");
    }
}
