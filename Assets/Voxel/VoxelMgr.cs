using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMgr : MultiSpawner {
    public GameObject watever;
    public GameObject voxel;
    public GameObject coin;
    public GameObject trigger;
    
    // Use this for initialization
    void Start ()
    {
        MultiSpawn(watever, 50, 100.0f, 500.0f, 200.0f, 5.0f, 0.5f, 20.0f);
        MultiSpawn(voxel, 50, 100.0f, 500.0f, 200.0f, 5.0f, 0.5f, 20.0f);
        MultiSpawn(coin, 100, 200.0f, 500.0f, 0.0f, 0.0f, 1.0f, 4.0f);
        MultiSpawn(trigger, 33, 200.0f, 500.0f, 40.0f, 10.0f, 0.5f, 20.0f);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
