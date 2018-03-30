using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shorelineVisual : MonoBehaviour {

	public GameObject shore1800_Prefab;
	public GameObject shore1930_Prefab;
	public GameObject shore2000_Prefab;

	public GameObject leftHand;
	public GameObject rightHand;
	public string lhName;
	public string rhName;

	
	public GameObject dlog;
	public dataLog dscript;
	public GameObject sl;

	private int counter = 0;

	void Start()
	{
		
		lhName = leftHand.name;
		rhName = rightHand.name;
		dscript = dlog.GetComponent<dataLog>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name.Equals(lhName) || col.gameObject.name.Equals(rhName))
		{
			dscript.logEvent(this.name);
			

			Debug.Log("counter is: " + counter);

			if (counter == 0)
			{
				
				sl = Instantiate(shore1800_Prefab);
				counter++;
			}
			else if (counter == 1)
			{
				
				Destroy(sl);
				sl = Instantiate(shore1930_Prefab);
				counter++;

			} else if (counter == 2){
				Destroy(sl);
				sl = Instantiate(shore2000_Prefab);
				counter++;

			}else{
				Destroy (sl);
				counter = 0;
	}
		}

}
}