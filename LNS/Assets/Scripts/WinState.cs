using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour {

    public GameObject instructions;
    public GameObject winText;
    public GameObject loseText;

    private void OnCollisionEnter2D(Collision2D col)
    {
        //win state
        if (col.gameObject.name == "Finish")
        {
            instructions.SetActive(false);
            winText.SetActive(true);
            Destroy(col.gameObject);
        }
        //lose state
        else if (
            col.gameObject.name.Contains("laser") || //laser
            col.gameObject.name.Contains("spike")    //spike
            )
        {
            instructions.SetActive(false);
            winText.SetActive(false);
            loseText.SetActive(true);
            Destroy(gameObject);
        }
    }
}
