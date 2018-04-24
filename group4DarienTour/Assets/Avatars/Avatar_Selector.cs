using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar_Selector : MonoBehaviour {

    public GameObject Avatar_Selector_UI;
    public GameObject Associated_Avatar;

   
    public GameObject rightHand;
    public string rhName;


    // Use this for initialization
    void Start () {

        rhName = rightHand.name;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
      {

         if (col.gameObject.name.Equals(rhName))
            {
            Associated_Avatar.SetActive(true);
            Avatar_Selector_UI.SetActive(false);
            }
        }
    }


    

