using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMgr : MonoBehaviour{

    public GameObject RespawnPoint;
    public GameObject Player;
    public GameObject cameraController;

	// Use this for initialization
	void Start ()
    {
        SpawnPlayer();
    }
	
    void SpawnPlayer()
    {
        GameObject playerObj = Instantiate(Player, RespawnPoint.transform.position, RespawnPoint.transform.rotation);
        Player player = playerObj.GetComponent<Player>();
        player.gameplayMgr = gameObject.GetComponent<GameplayMgr>();
        player.cameraController = cameraController.GetComponent<CameraController>();
        player.cameraController.player = player;
    }

    public void GameOver()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
