using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class TakePhoto : MonoBehaviour
{
    Texture2D screenCap;
    Texture2D border;
    bool shot = false;
    public GameObject rightHand;
    public string rhName;
    private int index;
    public GameObject ourHand;
    public GameObject ourCamera;
    private NetworkManagerHUD hud;
    public  GameObject OurButton;
    public GameObject[] cameraPeices;
    public AudioClip shutter;
    AudioSource audioSource;
    //public Material myMat;
    public float totalSeconds;     // The total of seconds the flash wil last
    public float maxIntensity;     // The maximum intensity the flash will reach
    public Light myLight;        // Your light


    // Use this for initialization
    void Start()
    {
        rhName = rightHand.name;
        screenCap = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false); // 1
        border = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false); // 2
        border.Apply();
        index = 0;
        OurButton = GameObject.Find("Button");
        hud =FindObjectOfType<NetworkManagerHUD>();
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider col)
    {
        

        if (col.gameObject.name.Equals(rhName))
        {
            ourHand.GetComponent<MeshRenderer>().enabled = false;
            foreach(GameObject i in cameraPeices)
            {
                MeshRenderer r = i.GetComponent<MeshRenderer>();
                r.enabled = false;
            }
            hud.showGUI = false;
            OurButton.SetActive(false);
           
            StartCoroutine("Capture");
  
        }
    }
    IEnumerator flash() {
        myLight.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        myLight.gameObject.SetActive(false);
    }

    IEnumerator Capture()
    {
        audioSource.Play();
        StartCoroutine("flash");
        yield return new WaitForEndOfFrame();
        screenCap.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenCap.Apply();

        // Encode texture into PNG
        byte[] bytes = screenCap.EncodeToPNG();
        //Object.Destroy(screenCap);
        string path = "/SavedScreen_"+ index + ".png";
        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + path, bytes);
        index++;
        shot = true;
        ourHand.GetComponent<MeshRenderer>().enabled = true;
        foreach (GameObject i in cameraPeices)
        {
            MeshRenderer r = i.GetComponent<MeshRenderer>();
            r.enabled = true;
        }
        hud.showGUI = true;
        OurButton.SetActive(true);

    }
}