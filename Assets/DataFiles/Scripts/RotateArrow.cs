using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var gameobject = new GameObject();
	    var rotation = gameobject.AddComponent<rotation>();
		transform.Rotate(rotation.calRotation(30, 0, 0));
	}

}
