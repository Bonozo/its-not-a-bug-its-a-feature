using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMgr : MultiSpawner {

    public GameObject voxel;
    public GameObject watever;

    // Use this for initialization
    void Start () {
        MultiSpawn(voxel, 50, 100.0f, 100.0f, 50.0f, 3.0f, 0.25f, 10.0f);
        MultiSpawn(watever, 25, 100.0f, 100.0f, 50.0f, 3.0f, 0.25f, 10.0f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
