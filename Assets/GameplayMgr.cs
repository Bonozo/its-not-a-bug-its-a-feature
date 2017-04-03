using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayMgr : MonoBehaviour{

    public GameObject RespawnPoint;
    public GameObject Player;
    public GameObject cameraController;
    public Text ScoreText;

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

    public void SetScore(int points)
    {
        if (ScoreText == null)
            return;

        ScoreText.text = points.ToString("D9");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
