using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Vector3 distance;
    public float duration = 0.0f;

    private Vector3 startspot;
    private Vector3 endspot;

    // Use this for initialization
    void Start ()
    {
        startspot = transform.position;
        endspot = startspot + distance;

        StartCoroutine( SmoothMove(startspot, endspot, duration) );
    }

    // Update is called once per frame
    void Update () {
		
	}

    private IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {

        bool pingpong = true;

        float direction = -1.0f;
        while (pingpong)
        {
            direction *= -1.0f;
            float t = 0.0f;

            while (t <= 1.0f)
            {
                t += Time.deltaTime / seconds;

                if(direction>0.0f)
                {
                    transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0.0f, 1.0f, t));
                }
                else
                {
                    transform.position = Vector3.Lerp(endpos, startpos, Mathf.SmoothStep(0.0f, 1.0f, t));
                }

                yield return null;
            }
        }
    }
}
