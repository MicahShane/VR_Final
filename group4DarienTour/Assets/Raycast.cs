using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

    public float TargetDistance;
    public GameObject ThingToHit;
    public string ThingToHitName;
    public float MaxRayDistance = 10;



    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.position + Vector3.forward * MaxRayDistance, Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)){
            hit.transform.SendMessage("Flood");
        }
    }
}

