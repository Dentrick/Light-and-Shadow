using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloor : MonoBehaviour {

    public PlayerControl PControl; //reference back to player control

    //temp
    ////collision check method
    //private void OnCollisionStay2D(Collision2D col)
    //{
    //    if (col.gameObject.name == "Floor" || col.gameObject.name.Contains("Block") || col.gameObject.name.Contains("shadow"))
    //    {
    //        PControl.isOnFloor = true;
    //    }
    //    Debug.Log("on floor");
    //}
    //
    ////collision uncheck method
    //private void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.name == "Floor" || col.gameObject.name.Contains("Block") || col.gameObject.name.Contains("shadow"))
    //        PControl.onFloor = false;
    //    Debug.Log("left floor");
    //}
}
