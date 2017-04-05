﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMgr : MultiSpawner {

    public GameObject voxel;
    public GameObject watever;
    public GameObject roid;
    public GameObject difficulty;
    public CrashMe crasher;

    // Use this for initialization
    void Start ()
    {
        MultiSpawnDef msd;
        
        msd = new MultiSpawnDef();
        msd.spawnObj = voxel;
        msd.Qty = 50;
        msd.posDiameter = 100.0f;
        msd.posLow = 0.0f;
        msd.posHeight = 100.0f;
        msd.moverDist = 50.0f;
        msd.moverDuration = 3.0f;
        msd.spawnScaleMin = 0.25f;
        msd.spawnScaleMax = 10.0f;
        MultiSpawn(msd);

        msd = new MultiSpawnDef();
        msd.spawnObj = watever;
        msd.Qty = 25;
        msd.posDiameter = 100.0f;
        msd.posLow = 0.0f;
        msd.posHeight = 100.0f;
        msd.moverDist = 50.0f;
        msd.moverDuration = 3.0f;
        msd.spawnScaleMin = 0.25f;
        msd.spawnScaleMax = 10.0f;
        MultiSpawn(msd);

        msd = new MultiSpawnDef();
        msd.spawnObj = roid;
        msd.Qty = 10;
        msd.posDiameter = 100.0f;
        msd.posLow = 0.0f;
        msd.posHeight = 100.0f;
        msd.moverDist = 0.0f;
        msd.moverDuration = 0.0f;
        msd.spawnScaleMin = 1.0f;
        msd.spawnScaleMax = 4.0f;
        MultiSpawn(msd);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void PressStart()
    {
        difficulty.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Story");
        SceneManager.LoadScene("Ship", LoadSceneMode.Additive);
    }

    public void DifficultyHard()
    {
        crasher.Crash();
    }

    public void DifficultyNorm()
    {
        LoadGame();
    }

    public void DifficultyEasy()
    {
        crasher.Crash();
    }
}
