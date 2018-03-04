using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floodSim : MonoBehaviour {
    public GameObject floodWater;
	public GameObject leftHand;
	public GameObject rightHand;
	public string lhName;
	public string rhName;

	// Use this for initialization
	void Start () {
		lhName = leftHand.name;
		rhName = rightHand.name;
	}
	
	// Update is called once per frame
	void Update () {
       /* if (Input.GetButtonDown("Fire1")) //change to cube collider 
        {
            floodWater.transform.Translate(Vector3.up * 1.2f);

        }*/
		
	}

	 void OnTriggerStay(Collider col)
	{
		if(col.gameObject.name.Equals(lhName) || col.gameObject.name.Equals(rhName))
		{
			Debug.Log("Its working!!");
			floodWater.transform.Translate(Vector3.up * 0.08f);


		}
	}
	
}
