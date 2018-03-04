using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrimping : MonoBehaviour {

	public GameObject ShrimpBoat_prefab;
	public GameObject leftHand;
	public GameObject rightHand;
	public string lhName;
	public string rhName;
	public GameObject sb;
	//public Renderer rend;
	private bool hideshow = false;
	//public Transform[] parents;

	// Use this for initialization
	void Start()
	{
		//parents = ShrimpBoat.GetComponentsInChildren<Transform>();
		lhName = leftHand.name;
		rhName = rightHand.name;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name.Equals(lhName) || col.gameObject.name.Equals(rhName))
		{
			
			//make shrimp boats appear and disappear
			hideshow = !hideshow;
			Debug.Log("Hideshow is: " + hideshow);

			if (hideshow)
			{

				//make shrimp boat appear
				sb = Instantiate(ShrimpBoat_prefab);
				
			}
			else
			{


				//make shrimp boat disappear
				Destroy(sb);
				
			}


		}
	}
}
