using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beams : MonoBehaviour
{
    public LineRenderer line;
    public float Speed = 1;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(DoBeamEffect());	
	}

    IEnumerator DoBeamEffect()
    {

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        GameObject obj1 = null;
        while(obj1 == null)
        {
            GameObject o = allObjects[ Random.Range(0, allObjects.Length)];
            if (o.tag == "Player") continue;
            if (o.GetComponentInChildren<MeshRenderer>() == null) continue;

            obj1 = o;
        }

        GameObject obj2 = null;
        while (obj2 == null)
        {
            GameObject o = allObjects[Random.Range(0, allObjects.Length)];
            if (o.tag == "Player") continue;
            if (o.GetComponentInChildren<MeshRenderer>() == null) continue;
            if (o == obj1) continue;

            obj2 = o;
        }

        Vector3[] points = new Vector3[2];
        points[0] = obj1.transform.position;
        points[1] = obj2.transform.position;
        line.SetPositions(points);

        this.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f));

        yield return new WaitForSeconds(Speed);

        StartCoroutine(DoBeamEffect());
    }
}
