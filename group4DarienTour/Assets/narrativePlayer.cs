using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narrativePlayer : MonoBehaviour {
	public AudioSource narrative;
	public GameObject Microphone;
	public string micName;

	public float playTime;
	public float initTime;

	public GameObject dlog;
	public dataLog dscript;

	// Use this for initialization
	void Start()
	{
		micName = Microphone.name;
		
		narrative = GetComponent<AudioSource>();
		initTime = playTime;
		dscript = dlog.GetComponent<dataLog>();
	}

	// Update is called once per frame
	void Update()
	{
		/* if (Input.GetButtonDown("Fire1")) //change to cube collider 
		 {
			 floodWater.transform.Translate(Vector3.up * 1.2f);

		 }*/

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name.Equals(micName))
		{
			dscript.logEvent(this.name);

			if (narrative.isPlaying)
			{
				narrative.Pause();
				Debug.Log("paused");
			}
			else
			{
				Debug.Log("Its playing!!");
				narrative.Play();
				StartCoroutine(clipTimer(playTime));
				
			}
			
			
		}

	}
	float currTime;
	bool isPaused = false;
	public IEnumerator clipTimer(float countdownValue)
	{
		currTime = countdownValue;
		while (currTime > 0 )
		{
			Debug.Log("Countdown: " + currTime);
			yield return new WaitForSeconds(1.0f);
			currTime--;
			if (!(narrative.isPlaying)&& narrative.time != 0)
			{
				playTime = currTime;
				isPaused = true;
				break;
			}
		}
		
		if (isPaused == false)
		{
			playTime = initTime;
			narrative.Stop();
		}
		else
		{
			isPaused = false;
		}
		}
}
