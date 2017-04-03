using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSpawner : MonoBehaviour
{

    public void MultiSpawn(GameObject spawnObj, int Qty, float posDiameter, float posHeight, float moverDist = 0.0f, float moverDuration = 0.0f, float spawnScaleMin = 1.0f, float spawnScaleMax = 1.0f)
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



}
