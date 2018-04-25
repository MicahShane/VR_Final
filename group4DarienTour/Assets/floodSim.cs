using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floodSim : MonoBehaviour {
    public GameObject floodWater;
	public GameObject head;
	public GameObject leftHand;
	public GameObject rightHand;
    public VRPlayer player;
    public string lhName;
	public string rhName;
   

	public GameObject dlog;
	public dataLog dscript;

	public GameObject fw;
    private Vector3 original_scale;
    private Vector3 target_scale;
    public Component halo;



    // Use this for initialization
    void Start()
    {
        lhName = leftHand.name;
        rhName = rightHand.name;
        dscript = dlog.GetComponent<dataLog>();
        original_scale = transform.localScale;
        target_scale = transform.localScale * 1.2f;
        halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
    }

  

     void OnTriggerStay(Collider col)
	{
        
       
        if (col.gameObject.name.Equals(lhName) || col.gameObject.name.Equals(rhName))
		{
            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
            transform.localScale = Vector3.Lerp(transform.localScale, target_scale , 0.3f);
            
            


            if (fw == null)
			{
			fw = Instantiate(floodWater);
			}

			if(head.transform.position.y > fw.transform.position.y)
			{
			fw.transform.Translate(Vector3.up * 0.005f);
			}
			else
			{
				Destroy(fw);
			}
		}
	}

    private void OnTriggerExit(Collider other)
    {
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        transform.localScale = original_scale;
      
    }

    void OnTriggerEnter(Collider col)
	{
		
        player.shake();
        if (col.gameObject.name.Equals(lhName) || col.gameObject.name.Equals(rhName))
		{
			dscript.logEvent(this.name);
		}
	}
}
