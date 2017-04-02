using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringObj : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (tag == "Player")
        {
            Rigidbody playerRigidBody = other.GetComponent<Rigidbody>();
            if(playerRigidBody)
            {
                playerRigidBody.AddForce(new Vector3(0.0f, 1000.0f, 0.0f));
            }
        }
    }
}
