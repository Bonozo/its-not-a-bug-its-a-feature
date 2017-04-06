using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	void Start ()
    {
        StartCoroutine(LoadMain());
    }

    IEnumerator LoadMain()
    {
        yield return new WaitForSeconds(11);

        SceneManager.LoadScene("Title");
    }

}
