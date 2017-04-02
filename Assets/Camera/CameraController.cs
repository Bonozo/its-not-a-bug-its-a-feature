using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float camDist = -15.0f;

    private Vector3 destPos;

	// Use this for initialization
	void Start ()
    {
        //destPos = player.transform.position;
        //transform.position = destPos;
    }

    public void GameOver()
    {
        player = null;
    }

    // Update is called once per frame
    void Update ()
    {
        if (player)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 playerDir = player.transform.forward;

            //2d destPos = playerPos + new Vector3(0.0f, 0.0f, camDist);

            //float vertical = -90.0f;// Input.GetAxis("Vertical") * 90.0f;
            //destPos = playerPos + ( Quaternion.AngleAxis(vertical, Vector3.left) * (playerDir * camDist) );

            destPos = playerPos + new Vector3(0.0f, -camDist, 0.0f);

            float x = Mathf.Lerp(transform.position.x, destPos.x, 1.0f);//Time.deltaTime);
            float y = Mathf.Lerp(transform.position.y, destPos.y, 1.0f);// Time.deltaTime * 8.0f);
            float z = Mathf.Lerp(transform.position.z, destPos.z, 1.0f);//Time.deltaTime);

            transform.position = new Vector3(x, y, z);
            transform.LookAt(player.transform);
        }
    }
}
