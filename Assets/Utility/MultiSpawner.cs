using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSpawner : MonoBehaviour
{
    public class MultiSpawnDef
    {
        public GameObject spawnObj;
        public int Qty;
        public float posDiameter;
        public float posLow;
        public float posHeight;
        public float moverDist = 0.0f;
        public float moverDuration = 0.0f;
        public float spawnScaleMin = 1.0f;
        public float spawnScaleMax = 1.0f;
    }

    public GameObject MultiSpawn(MultiSpawnDef multiSpawnDef)
    {
        if (multiSpawnDef.spawnObj == null)
        {
            Debug.LogError("MultiSpawn: GameObject missing.");
            return null;
        }

        GameObject Zone = new GameObject("Zone" + multiSpawnDef.spawnObj.name);


        for (int i = 0; i < multiSpawnDef.Qty; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-multiSpawnDef.posDiameter * 0.5f, multiSpawnDef.posDiameter * 0.5f),
                Random.Range(multiSpawnDef.posLow, multiSpawnDef.posHeight),
                Random.Range(-multiSpawnDef.posDiameter * 0.5f, multiSpawnDef.posDiameter * 0.5f));

            GameObject voxelObj = Instantiate(multiSpawnDef.spawnObj, spawnPos, Quaternion.identity);
            voxelObj.transform.parent = Zone.transform;

            Vector3 spawnSacle = new Vector3(
                Random.Range(multiSpawnDef.spawnScaleMin, multiSpawnDef.spawnScaleMax),
                Random.Range(multiSpawnDef.spawnScaleMin, multiSpawnDef.spawnScaleMax),
                Random.Range(multiSpawnDef.spawnScaleMin, multiSpawnDef.spawnScaleMax));

            voxelObj.transform.localScale = spawnSacle;

            Mover voxelMover = voxelObj.GetComponent<Mover>();
            if (voxelMover)
            {
                Vector3 distance = new Vector3(
                    Random.Range(-multiSpawnDef.moverDist * 0.5f, multiSpawnDef.moverDist * 0.5f),
                    Random.Range(-multiSpawnDef.moverDist * 0.5f, multiSpawnDef.moverDist * 0.5f),
                    Random.Range(-multiSpawnDef.moverDist * 0.5f, multiSpawnDef.moverDist * 0.5f));

                voxelMover.distance = distance;
                voxelMover.duration = multiSpawnDef.moverDuration * 0.25f + Random.Range( 0.0f, multiSpawnDef.moverDuration * 0.75f );
            }
        }

        return Zone;
    }



}
