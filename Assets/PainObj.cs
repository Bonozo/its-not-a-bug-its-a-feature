using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainObj : MonoBehaviour {

    public GameObject xploPfx;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if( other.transform.tag == "Player")
        {
            Player player = other.transform.root.gameObject.GetComponent<Player>();
            if (player)
            {
                float dmg = other.rigidbody.velocity.magnitude / 100.0f;
                player.PlayerHit(dmg);
            }

            if(xploPfx)
            {
                GameObject xploObj = Instantiate(xploPfx, gameObject.transform.position, Quaternion.identity);
                if(xploObj == null)
                {
                    Debug.LogError("PainObj OnCollisionEnter: xploObj failed.");
                }
                else
                {
                    xploObj.transform.localScale *= 25.0f;// other.transform.localScale;
                }
                Destroy(gameObject);
            }
            //Debug.LogError("Player hit with " + other.collider.name);
        }
    }
}
