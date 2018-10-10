using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour {

    public GameObject instructions;
    public GameObject winText;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Finish")
        {
            instructions.SetActive(false);
            winText.SetActive(true);
            Destroy(col.gameObject);
        }
    }
}
