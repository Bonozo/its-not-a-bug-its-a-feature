using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Readout : MonoBehaviour {

    public Text TextObj;
    public float charDelay = 0.0f;
    public string readoutText;
    public AudioSource readoutSfx;

    private string readoutParsed;
    private int readoutIdx = 0;
    private float elapsed = 0.0f;
    private bool readoutDone = false;
    
	// Use this for initialization
	void Start ()
    {
        readoutParsed = readoutText.Replace("^", "\n");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (readoutDone == false)
        {
            elapsed += Time.fixedDeltaTime;

            int endPos = (int)(elapsed / charDelay);
            if (endPos > readoutParsed.Length)
            {
                endPos = readoutParsed.Length;
                readoutDone = true;
                readoutSfx.loop = false;
            }

            TextObj.text = readoutParsed.Substring(0, endPos);
        }
    }
}
