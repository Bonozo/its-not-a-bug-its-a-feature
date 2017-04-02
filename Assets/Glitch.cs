using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour {

    public Material glitchMat;
    private Material originalMat;
    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start ()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        originalMat = meshRenderer.material;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
        if( Random.value < 0.25f )
        {
            meshRenderer.material = glitchMat;
        }
        else
        {
            meshRenderer.material = originalMat;
        }
        	
	}
}
