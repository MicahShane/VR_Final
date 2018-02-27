using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameManager : MonoBehaviour {

	public GameObject vrCameraRig;
	public GameObject nonVRCameraRig;
	public Blinker hmdBlinker;
	public Transform SteamVR_Rig;
	public SteamVR_TrackedObject hmd;
	public SteamVR_TrackedObject controllerLeft;
	public SteamVR_TrackedObject controllerRight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enableVR(){
		StartCoroutine(doEnableVR());
	}

	IEnumerator doEnableVR(){
		while(XRSettings.loadedDeviceName != "OpenVR"){
			XRSettings.LoadDeviceByName("OpenVR");
			yield return null;
		}
		XRSettings.enabled = true;
		vrCameraRig.SetActive(true);
		nonVRCameraRig.SetActive(false);
	}
}
