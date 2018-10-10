using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCamera : MonoBehaviour {

    public Vector2 resolution = new Vector2(1200, 600);

	// Use this for initialization
	void Start () {
        Screen.SetResolution((int)resolution.x, (int)resolution.y, false);
	}
}
