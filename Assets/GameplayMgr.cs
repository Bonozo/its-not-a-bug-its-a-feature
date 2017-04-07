using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayMgr : MultiSpawner{

    public const float veloThresh = 10000.0f; // it's not a bug, it's a feature

    public GameObject RespawnPoint;
    public GameObject Player;
    public GameObject cameraController;
    public Text ScoreText;
    public Text HpText;
    public Text HiScoreText;
    public Text SpeedText;
    public GameObject watever;
    public GameObject voxel;
    public GameObject coin;
    public GameObject trigger;
    public GameObject roid;
    public GameObject mine;
    public GameObject ring;
    public CrashMe crasher;
    public GameObject HelpPopup;

    [SerializeField]
    private int hiScore = 0;
    private int prevZoneCache;
    private GameObject[] zoneObjs = new GameObject[2];
    int zoneIdx;
    private GameObject playerObj;
    private Player playerObjPlayer;
    private int currStage = 0;

    // Use this for initialization
    void Start ()
    {
        hiScore = PlayerPrefs.GetInt("hiscore", 0);
        DisplayHiScore();

        SpawnPlayer();
    }
	
    void SpawnPlayer()
    {
        playerObj = Instantiate(Player, RespawnPoint.transform.position, RespawnPoint.transform.rotation);
        prevZoneCache = 999999;
        zoneIdx = 0;
        currStage = 0;
        playerObjPlayer = playerObj.GetComponent<Player>();
        playerObjPlayer.gameplayMgr = gameObject.GetComponent<GameplayMgr>();
        playerObjPlayer.cameraController = cameraController.GetComponent<CameraController>();
        playerObjPlayer.cameraController.player = playerObjPlayer;
    }

    public void GameOver()
    {
        if( PlayerPrefs.GetString("difficulty") == "hard")
        {
            crasher.Crash();
        }

        SpawnPlayer();
    }

    public void SetScore(int points)
    {
        if (ScoreText == null)
            return;

        ScoreText.text = (points / 100).ToString();

        if (points > hiScore)
        {
            hiScore = points;
            PlayerPrefs.SetInt("hiscore", points);
            DisplayHiScore();
        }

    }

    private void DisplayHiScore()
    {
        HiScoreText.text = (hiScore / 100).ToString();
    }

    public void SetHP(int points)
    {
        if (HpText == null)
            return;

        HpText.text = points.ToString();
    }

    private void UpdateSpeed()
    {
        float speed = playerObjPlayer.rigidBody.velocity.magnitude;

        SpeedText.text = speed.ToString("F2");

        if( speed > veloThresh || speed < -veloThresh )
        {
            SpeedText.color = Color.red;
        }
        else
        {
            SpeedText.color = Color.white;
        }
    }

    void SpawnZone(float posLow, float posHeight)
    {
        GameObject objToSpawn;
        int select = Random.Range(0, 7);
        switch (select)
        {
            case 0: objToSpawn = watever; break;
            case 1: objToSpawn = voxel; break;
            case 2: objToSpawn = coin; break;
            case 3: objToSpawn = trigger; break;
            case 4: objToSpawn = roid; break;
            case 5: objToSpawn = mine; break;
            default: objToSpawn = ring; break;
        }
        MultiSpawnDef msd = new MultiSpawnDef();
        msd.spawnObj = objToSpawn;
        msd.Qty = 100;
        msd.posDiameter = 400.0f;
        msd.posLow = posLow;
        msd.posHeight = posHeight;
        msd.moverDist = 0.0f;
        msd.moverDuration = 0.0f;
        msd.spawnScaleMin = 5.0f + currStage * 2;
        msd.spawnScaleMax = 10.0f + currStage * 2;
        zoneObjs[zoneIdx] = MultiSpawn(msd);
    }

    // Update is called once per frame
    void Update ()
    {
        if (playerObj)
        {
            float currPlayerY = playerObjPlayer.rigidBody.transform.position.y;

            int currZone = Mathf.FloorToInt(currPlayerY / 1000.0f);
            if(currZone < prevZoneCache)
            {
                float posHeight = 1000.0f * currZone;
                float posLow = posHeight - 1000.0f;

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

                currStage++;
            }



            //MultiSpawn(watever, 50, 100.0f, posLow, posHeight, 200.0f, 5.0f, 0.5f, 20.0f);
            //MultiSpawn(voxel, 50, 100.0f, posLow, posHeight, 200.0f, 5.0f, 0.5f, 20.0f);
            //MultiSpawn(trigger, 33, 200.0f, posLow, posHeight, 40.0f, 10.0f, 0.5f, 20.0f);
            //MultiSpawn(roid, 33, 200.0f, posLow, posHeight, 40.0f, 10.0f, 0.5f, 10.0f);

            prevZoneCache = currZone;


            UpdateSpeed();
            UpdateHelp();
        }

    }

    public void UpdateHelp()
    {
        if(playerObjPlayer.rigidBody.transform.position.y < 300.0f )
        {
            HelpPopup.SetActive(false);
        }
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
