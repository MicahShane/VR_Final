using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survey_Handler : MonoBehaviour
{

    public GameObject dlog;
    public dataLog dscript;
    public GameObject parentSurvey;

    public GameObject leftHand;
    public GameObject rightHand;
    public string lhName;
    public string rhName;

    private bool answered;
    public GameObject triggerObject;
    

 


    // Use this for initialization
    void Start()
    {
        dlog = GameObject.Find("DataLogger");
        lhName = leftHand.name;
        rhName = rightHand.name;
        dscript = dlog.GetComponent<dataLog>();
        answered = false;
        triggerObject = GameObject.Find("SurveyTrigger");

       

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name.Equals(rhName) || col.gameObject.name.Equals(lhName))
        {
            Debug.Log("You have selected " + this.gameObject.name);
            dscript.logEvent(this.name);
            answered = true;
            triggerObject.GetComponent<SurveyTrigger>().RemoveSurvey(this.transform.root.name);
        }
    }


}
