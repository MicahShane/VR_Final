using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyTrigger : MonoBehaviour {

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject survey1;
    public GameObject survey2;
    public string lhName;
    public string rhName;

    public GameObject s1;
    public GameObject s2;

    // Use this for initialization
    void Start () {
        lhName = leftHand.name;
        rhName = rightHand.name;

    }
	
	// Update is called once per frame
	void Update () {

		
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name.Equals(rhName) || col.gameObject.name.Equals(lhName))
        {
            s1 = Instantiate(survey1);
            s2 = Instantiate(survey2);
        }
    }
}
