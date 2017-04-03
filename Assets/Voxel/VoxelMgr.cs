using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMgr : MonoBehaviour {
    public GameObject watever;
    public GameObject voxel;
    public GameObject coin;
    public GameObject trigger;
    public int Qty = 0;
    
    void MultiSpawner(GameObject spawnObj, int Qty, float posDiameter, float posHeight, float moverDist = 0.0f, float moverDuration = 0.0f, float spawnScaleMin = 1.0f, float spawnScaleMax = 1.0f)
    {
        for (int i = 0; i < Qty; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-posDiameter * 0.5f, posDiameter * 0.5f),
                Random.Range(0.0f, posHeight),
                Random.Range(-posDiameter * 0.5f, posDiameter * 0.5f));

            GameObject voxelObj = Instantiate(spawnObj, spawnPos, Quaternion.identity);

            Vector3 spawnSacle = new Vector3(
                Random.Range(spawnScaleMin, spawnScaleMax),
                Random.Range(spawnScaleMin, spawnScaleMax),
                Random.Range(spawnScaleMin, spawnScaleMax));

            voxelObj.transform.localScale = spawnSacle;

            Mover voxelMover = voxelObj.GetComponent<Mover>();
            if (voxelMover)
            {
                Vector3 distance = new Vector3(
                    Random.Range(-moverDist * 0.5f, moverDist * 0.5f),
                    Random.Range(-moverDist * 0.5f, moverDist * 0.5f),
                    Random.Range(-moverDist * 0.5f, moverDist * 0.5f));

                voxelMover.distance = distance;
                voxelMover.duration = 5.0f;
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        MultiSpawner(watever, 50, 100.0f, 500.0f, 200.0f, 5.0f, 0.5f, 20.0f);
        MultiSpawner(voxel, 50, 100.0f, 500.0f, 200.0f, 5.0f, 0.5f, 20.0f);
        MultiSpawner(coin, 100, 200.0f, 500.0f, 0.0f, 0.0f, 1.0f, 4.0f);
        MultiSpawner(trigger, 33, 200.0f, 500.0f, 40.0f, 10.0f, 0.5f, 20.0f);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
