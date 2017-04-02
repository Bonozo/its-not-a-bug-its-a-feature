using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMgr : MonoBehaviour {

    public GameObject voxel;
    public GameObject coin;
    public GameObject trigger;
    public int Qty = 0;
    

	// Use this for initialization
	void Start (){

        for (int i = 0; i < Qty; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-50.0f, 50.0f),
                Random.Range(   0.0f, 500.0f),
                Random.Range(-50.0f, 50.0f));

            GameObject voxelObj = Instantiate(voxel, spawnPos, Quaternion.identity);

            Vector3 spawnSacle = new Vector3(
                Random.Range(0.5f, 20.0f),
                Random.Range(0.5f, 20.0f),
                Random.Range(0.5f, 20.0f));

            voxelObj.transform.localScale = spawnSacle;

            Mover voxelMover = voxelObj.GetComponent<Mover>();
            if(voxelMover)
            {
                Vector3 distance = new Vector3(
                    Random.Range(-100.0f, 100.0f),
                    Random.Range(-100.0f, 100.0f),
                    Random.Range(-100.0f, 100.0f));

                voxelMover.distance = distance;
                voxelMover.duration = 5.0f;
            }
        }

        for (int i = 0; i < Qty; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-100.0f, 100.0f),
                Random.Range(0.0f, 500.0f),
                Random.Range(-100.0f, 100.0f));

            GameObject voxelObj = Instantiate(coin, spawnPos, Quaternion.identity);

            Vector3 spawnSacle = new Vector3(
                Random.Range(0.5f, 20.0f),
                Random.Range(0.5f, 20.0f),
                Random.Range(0.5f, 20.0f));

            //voxelObj.transform.localScale = spawnSacle;

            Mover voxelMover = voxelObj.GetComponent<Mover>();
            if (voxelMover)
            {
                Vector3 distance = new Vector3(
                    Random.Range(-20.0f, 20.0f),
                    Random.Range(-20.0f, 20.0f),
                    Random.Range(-20.0f, 20.0f));

                voxelMover.distance = distance;
                voxelMover.duration = 10.0f;
            }
        }

        for (int i = 0; i < Qty/3; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-100.0f, 100.0f),
                Random.Range(0.0f, 500.0f),
                Random.Range(-100.0f, 100.0f));

            GameObject voxelObj = Instantiate(trigger, spawnPos, Quaternion.identity);

            Vector3 spawnSacle = new Vector3(
                Random.Range(0.5f, 20.0f),
                Random.Range(0.5f, 20.0f),
                Random.Range(0.5f, 20.0f));

            voxelObj.transform.localScale = spawnSacle;

            Mover voxelMover = voxelObj.GetComponent<Mover>();
            if (voxelMover)
            {
                Vector3 distance = new Vector3(
                    Random.Range(-20.0f, 20.0f),
                    Random.Range(-20.0f, 20.0f),
                    Random.Range(-20.0f, 20.0f));

                voxelMover.distance = distance;
                voxelMover.duration = 10.0f;
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
