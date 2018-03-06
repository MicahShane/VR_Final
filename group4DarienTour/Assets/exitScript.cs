using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class exitScript : MonoBehaviour {

	public GameObject dlog;
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject vrCameraRig;
	public GameObject nonVRCameraRig;
	public string lhName;
	public string rhName;
	public dataLog dscript;

	// Use this for initialization
	void Start () {
		dscript = dlog.GetComponent<dataLog>();
		lhName = leftHand.name;
		rhName = rightHand.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
	if(col.gameObject.name.Equals(lhName) || col.gameObject.name.Equals(rhName)){
		dscript.logEvent(this.name);
		nonVRCameraRig.SetActive(true);
		vrCameraRig.SetActive(false);
		UnityEngine.XR.XRSettings.enabled = false;
		dscript.endLog();
	}
		
		}
	
}
