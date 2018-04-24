using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTalk : MonoBehaviour {

	public Animator anim;
	public bool talk;
	

	void start(){
		anim = GetComponent<Animator>();
        talk = false;
		anim.SetBool("talk",talk);
	}

	void OnTriggerEnter(Collider col)
	{
		talk = true;
		anim.SetBool("talk",talk);
		StartCoroutine(StopTalking(10));
	}

	float currtime;
	public IEnumerator StopTalking(float countdownValue){
		currtime = countdownValue;
		while (currtime > 0){
			yield return new WaitForSeconds(1.0f);
			currtime --;
		}
		talk = false;
		anim.SetBool("talk",talk);
	}

}
