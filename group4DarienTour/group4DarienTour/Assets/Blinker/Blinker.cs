using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour {

	public Material myMat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, myMat);
	}
	public void blink(float t)
	{
		StartCoroutine(doBlink(t));
	}
	IEnumerator doBlink(float t)
	{
		float tt = 0;
		while (tt < t)
		{
			Debug.Log(tt);
			tt = tt + Time.deltaTime;
			if (tt >= t)
			{
				tt = t;
			}
			myMat.SetColor("_BlinkColor", Color.Lerp(Color.white, Color.black, tt / t));
			yield return null;
		}
		tt = 0;
		while (tt < t)
		{

			tt = tt + Time.deltaTime;
			if (tt >= t)
			{
				tt = t;
			}
			myMat.SetColor("_BlinkColor", Color.Lerp(Color.black, Color.white, tt / t));
			yield return null;
		}
	}
}
