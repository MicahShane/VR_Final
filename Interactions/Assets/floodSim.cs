using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floodSim : MonoBehaviour {
    public GameObject floodWater;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) //change to cube collider 
        {
            floodWater.transform.Translate(Vector3.up * 1.2f);

        }
	}
}
