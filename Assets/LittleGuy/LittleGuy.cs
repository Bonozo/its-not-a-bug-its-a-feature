using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGuy : MonoBehaviour {

    public Rigidbody rootBone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rootBone.AddForce(new Vector3(0.0f, 500.0f, 0.0f));
        }
    }


}
