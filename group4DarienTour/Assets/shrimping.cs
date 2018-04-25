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

	public GameObject dlog;
	public dataLog dscript;

    private Vector3 original_scale;
    private Vector3 target_scale;

    public Component halo;

    // Use this for initialization
    void Start()
	{
		//parents = ShrimpBoat.GetComponentsInChildren<Transform>();
		lhName = leftHand.name;
		rhName = rightHand.name;

        original_scale = transform.localScale;
        target_scale = transform.localScale * 1.2f;

        dscript = dlog.GetComponent<dataLog>();

        halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
    }

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name.Equals(lhName) || col.gameObject.name.Equals(rhName))
		{
			dscript.logEvent(this.name);
			
			
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
}
