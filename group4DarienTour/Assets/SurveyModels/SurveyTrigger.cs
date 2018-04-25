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

    private Vector3 original_scale;
    private Vector3 target_scale;

    public Component halo;



    public GameObject s1;
    public GameObject s2;

    // Use this for initialization
    void Start () {
        lhName = leftHand.name;
        rhName = rightHand.name;

        original_scale = transform.localScale;
        target_scale = transform.localScale * 1.2f;

        halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);

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

    void OnTriggerStay(Collider col)
    {
        transform.localScale = Vector3.Lerp(transform.localScale, target_scale, 0.3f);
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.localScale = original_scale;
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
    }

    public void RemoveSurvey(string p)
    {
        if (p == "Survey1(Clone)")
        {
            Destroy(s1);
        }
        else if(p == "Survey2(Clone)")
        {
            Destroy(s2);
        }
        else
        {
            Debug.Log("Something went wrong deleting survey. " + p + " was called for destroying.");

        }
        //do a thing
    }
}
