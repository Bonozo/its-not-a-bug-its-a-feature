using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryMgr : MonoBehaviour {

    public Readout readout;
    public GameObject player;
    public GameObject xploPfx;
    public float xploScale = 1.0f;

    private bool IsDone = false;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(readout.IsDone && !IsDone)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if( player )
            {
                if (xploPfx)
                {
                    GameObject xploObj = Instantiate(xploPfx, player.transform.position, Quaternion.identity);
                    xploObj.transform.localScale *= xploScale;
                }

                player.SetActive(false);
            }

            IsDone = true;
        }
	}

    public void Next()
    {
        SceneManager.LoadScene("Game");
    }
}
