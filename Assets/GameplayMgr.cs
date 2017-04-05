using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayMgr : MultiSpawner{

    public GameObject RespawnPoint;
    public GameObject Player;
    public GameObject cameraController;
    public Text ScoreText;
    public Text HpText;

    public GameObject watever;
    public GameObject voxel;
    public GameObject coin;
    public GameObject trigger;
    public GameObject roid;

    private int prevZoneCache;
    private GameObject[] zoneObjs = new GameObject[2];
    int zoneIdx;
    private GameObject playerObj;
    private Player playerObjPlayer;

    // Use this for initialization
    void Start ()
    {
        SpawnPlayer();
    }
	
    void SpawnPlayer()
    {
        playerObj = Instantiate(Player, RespawnPoint.transform.position, RespawnPoint.transform.rotation);
        prevZoneCache = 999999;
        zoneIdx = 0;
        playerObjPlayer = playerObj.GetComponent<Player>();
        playerObjPlayer.gameplayMgr = gameObject.GetComponent<GameplayMgr>();
        playerObjPlayer.cameraController = cameraController.GetComponent<CameraController>();
        playerObjPlayer.cameraController.player = playerObjPlayer;
    }

    public void GameOver()
    {
        SpawnPlayer();
    }

    public void SetScore(int points)
    {
        if (ScoreText == null)
            return;

        ScoreText.text = points.ToString("D9");
    }

    public void SetHP(int points)
    {
        if (HpText == null)
            return;

        HpText.text = points.ToString();
    }

    void SpawnZone(float posLow, float posHeight)
    {
        GameObject objToSpawn;
        int select = 1;// Random.Range(0, 4);
        switch (select)
        {
            case 0: objToSpawn = watever; break;
            case 1: objToSpawn = voxel; break;
            case 2: objToSpawn = coin; break;
            case 3: objToSpawn = trigger; break;
            default: objToSpawn = roid; break;
        }
        MultiSpawnDef msd = new MultiSpawnDef();
        msd.spawnObj = objToSpawn;
        msd.Qty = 100;
        msd.posDiameter = 200.0f;
        msd.posLow = posLow;
        msd.posHeight = posHeight;
        msd.moverDist = 0.0f;
        msd.moverDuration = 0.0f;
        msd.spawnScaleMin = 50.0f;
        msd.spawnScaleMax = 50.0f;
        zoneObjs[zoneIdx] = MultiSpawn(msd);
    }

    // Update is called once per frame
    void Update ()
    {
        if (playerObj)
        {
            float currPlayerY = playerObjPlayer.rigidBody.transform.position.y;

            int currZone = Mathf.FloorToInt(currPlayerY / 500.0f);
            if(currZone < prevZoneCache)
            {
                float posHeight = 500.0f * currZone;
                float posLow = posHeight - 500.0f;

                if (zoneObjs[zoneIdx] == null)
                {
                    // fill in the zone double buffer before cycling
                    SpawnZone(posLow, posHeight);
                }
                else
                {
                    Destroy(zoneObjs[zoneIdx]);
                    SpawnZone(posLow, posHeight);
                }

                zoneIdx ^= 1;
            }



            //MultiSpawn(watever, 50, 100.0f, posLow, posHeight, 200.0f, 5.0f, 0.5f, 20.0f);
            //MultiSpawn(voxel, 50, 100.0f, posLow, posHeight, 200.0f, 5.0f, 0.5f, 20.0f);
            //MultiSpawn(trigger, 33, 200.0f, posLow, posHeight, 40.0f, 10.0f, 0.5f, 20.0f);
            //MultiSpawn(roid, 33, 200.0f, posLow, posHeight, 40.0f, 10.0f, 0.5f, 10.0f);

            prevZoneCache = currZone;

        }

    }
}
