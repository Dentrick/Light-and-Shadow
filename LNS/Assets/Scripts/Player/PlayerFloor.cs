using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloor : MonoBehaviour {

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
            coyoteTimer = coyoteTime;
        Debug.Log("left floor");
    }
}
