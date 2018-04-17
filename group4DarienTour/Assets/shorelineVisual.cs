using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shorelineVisual : MonoBehaviour {

	public GameObject shore1800_Prefab;
	public GameObject shore1930_Prefab;
	public GameObject shore2000_Prefab;
    public GameObject shore1800_Text;
    public GameObject shore1930_Text;
    public GameObject shore2000_Text;


    public GameObject leftHand;
	public GameObject rightHand;
	public string lhName;
	public string rhName;

	
	public GameObject dlog;
	public dataLog dscript;
	public GameObject sl;
    public GameObject st;

    private int counter;

	void Start()
	{
		
		lhName = leftHand.name;
		rhName = rightHand.name;
		dscript = dlog.GetComponent<dataLog>();
        counter = 0;
         
	}

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name.Equals(rhName))
        {

            dscript.logEvent(this.name);


            Debug.Log("counter is: " + counter);

            if (counter == 0)
            {
                st = Instantiate(shore1800_Text);
                sl = Instantiate(shore1800_Prefab);
                counter++;
            }
            else if (counter == 1)
            {

                Destroy(sl);
                Destroy(st);
                st = Instantiate(shore1930_Text);
                sl = Instantiate(shore1930_Prefab);
              
                counter++;

            }
            else if (counter == 2)
            {
                ;
                Destroy(sl);
                Destroy(st);
                st = Instantiate(shore2000_Text);
                sl = Instantiate(shore2000_Prefab);
              
                counter++;

            }
            else
            {
                Destroy(st);
                Destroy(sl);
                counter = 0;
            }
        }
    }


}