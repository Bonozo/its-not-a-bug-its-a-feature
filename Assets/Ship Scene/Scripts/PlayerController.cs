using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = gameObject.transform.position;
        pos.z -= speed;
        gameObject.transform.position = pos;
		
	}
}
