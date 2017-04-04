using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Readout : MonoBehaviour {

    public Text TextObj;
    public float charDelay = 0.0f;
    public string readoutText;

    private string readoutParsed;
    private int readoutIdx = 0;
    private float elapsed = 0.0f;

	// Use this for initialization
	void Start ()
    {
        readoutParsed = readoutText.Replace("^", "\n");
    }
	
	// Update is called once per frame
	void Update ()
    {
        elapsed += Time.fixedDeltaTime;

        int endPos = (int)(elapsed / charDelay);
        if (endPos > readoutParsed.Length)
            endPos = readoutParsed.Length;

        TextObj.text = readoutParsed.Substring(0, endPos);
    }
}
