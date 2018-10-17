using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : MonoBehaviour {

    public PlayerControl PControl; //reference back to player control

    //temp
    ////collision check method (enter walljump mode once)
    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.name.Contains("shadow"))
    //    {
    //        PControl.velocity = 0;
    //    }
    //    Debug.Log("enter walljump mode");
    //}
    //
    ////collision check method (enter walljump mode)
    //private void OnCollisionStay2D(Collision2D col)
    //{
    //    if (col.gameObject.name.Contains("shadow"))
    //    {
    //        PControl.currMass = PControl.grabMass;
    //        PControl.canJump = true; //allow jump
    //    }
    //    Debug.Log("in walljump mode");
    //}
    //
    ////collision uncheck method (leave walljump mode)
    //private void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.name.Contains("shadow"))
    //    {
    //        PControl.currMass = PControl.mass;
    //        PControl.canJump = false; //disallow jump
    //    }
    //    Debug.Log("left walljump mode");
    //}
}
