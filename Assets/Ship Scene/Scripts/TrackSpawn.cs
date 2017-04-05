using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawn : MonoBehaviour
{
    public int totalTrackPieces = 50;
    [RangeAttribute(1, 20)]
    public int pieceRepeat = 3;

    public GameObject start;
    public GameObject finish;

	void Start ()
    {
        Vector3 pp = Vector3.zero;

        //create start
        GameObject t = Instantiate(start, pp, Quaternion.identity);
        pp.z -= t.GetComponentInChildren<Renderer>().bounds.size.z;

        for (int i=0; i< totalTrackPieces; i++)
        {
            TrackConnect tc = t.GetComponent<TrackConnect>();
            if (tc)
            {
                GameObject g = tc.trackConnections[Random.Range(0, tc.trackConnections.Capacity)];

                for (int l=0; l< pieceRepeat; l++)
                {
                    Instantiate(g, pp, Quaternion.identity);
                    pp.z -= g.GetComponentInChildren<Renderer>().bounds.size.z;
                }

                t = g;
            }
            else
            {
                Debug.Log("Missing connections!" + t.name);
            }
        }

        //create end
        Instantiate(finish, pp, Quaternion.identity);

    }

}
