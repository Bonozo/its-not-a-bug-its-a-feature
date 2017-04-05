using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawn : MonoBehaviour
{
    public int totalTrackPieces = 50;
    [RangeAttribute(1, 20)]
    public int pieceRepeat = 3;

    public float rotateSpeed = 1;

    public GameObject start;
    public GameObject finish;

    private GameObject track;
    private float rotateAngle = 0;

    void Start()
    {
        track = new GameObject();
        track.transform.position = new Vector3(0, 50, 0);

        Vector3 pp = Vector3.zero;

        //create start
        GameObject ts = Instantiate(start, pp, Quaternion.identity);
        ts.transform.parent = track.transform;

        pp.z -= ts.GetComponentInChildren<Renderer>().bounds.size.z;

        for (int i = 0; i < totalTrackPieces; i++)
        {
            TrackConnect tc = ts.GetComponent<TrackConnect>();
            if (tc)
            {
                GameObject t = tc.trackConnections[Random.Range(0, tc.trackConnections.Capacity)];

                for (int l = 0; l < pieceRepeat; l++)
                {
                    GameObject tp = Instantiate(t, pp, Quaternion.identity);
                    tp.transform.parent = track.transform;

                    pp.z -= tp.GetComponentInChildren<Renderer>().bounds.size.z;
                    ts = tp;
                }
            }
            else
            {
                Debug.Log("Missing connections!" + tc.name);
            }
        }

        //create end
        GameObject ep = Instantiate(finish, pp, Quaternion.identity);
        ep.transform.parent = track.transform;

    }

    private void Update()
    {
        track.transform.RotateAround(Vector3.forward, rotateAngle);
        rotateAngle += .001f;

    }
}