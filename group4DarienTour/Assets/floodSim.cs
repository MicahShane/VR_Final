using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floodSim : MonoBehaviour {
    public GameObject floodWater;
	public GameObject head;
	public GameObject leftHand;
	public GameObject rightHand;
	public string lhName;
	public string rhName;

	public GameObject dlog;
	public dataLog dscript;

	public GameObject fw;

	// Use this for initialization
	void Start () {
		lhName = leftHand.name;
		rhName = rightHand.name;
		dscript = dlog.GetComponent<dataLog>();
	}
	

	 void OnTriggerStay(Collider col)
	{
		if(col.gameObject.name.Equals(lhName) || col.gameObject.name.Equals(rhName))
		{
			
			if (fw == null)
			{
			fw = Instantiate(floodWater);
			}

			if(head.transform.position.y > fw.transform.position.y)
			{
			Debug.Log("Its working!!");
			fw.transform.Translate(Vector3.up * 0.005f);
			}
			else
			{
				Destroy(fw);
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name.Equals(lhName) || col.gameObject.name.Equals(rhName))
		{
			dscript.logEvent(this.name);
		}
	}
}
