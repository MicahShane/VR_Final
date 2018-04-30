using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class dataLog : MonoBehaviour {
	char[] csvTokens = new[] { '\"', ',', '\n', '\r' };

   
	public string identifier = "group1";
	StreamWriter writer;
	// Use this for initialization
	void Start () {
		startLog(identifier);
	}
	
	// Update is called once per frame
	void Update () {}
		

	public void startLog(string identifier)
	{
		if(writer != null)
		{
			endLog();
			writer = null;
		}
        //create a file
        string filename = "./Resources/DataLog/" + identifier +"_" + (long)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970,1,1)).TotalSeconds) +  ".csv";
		Debug.Log("creating: " + filename);
		writer = new StreamWriter(filename);
	}
	public void endLog()
	{
		if(writer != null)
		{
			
			writer.Close();
			writer = null;
		}
	}
	public void logEvent(string eventName)
	{
		eventName = csvEscape(eventName);
		writer.WriteLine(eventName + "," + Time.time);
	}

	string csvEscape(string s)
	{
		if (s.IndexOfAny(csvTokens) >= 0)
		{
			s = "\"" + s.Replace("\"", "\"\"") + "\"";
		}
		return s;
	}

}
