#if HAMMERSEDGE
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class lel : MonoBehaviour {
	void Update ()
    {
        object[] objs = AssetDatabase.LoadAllAssetsAtPath("Assets");
        for(int i=0; i < objs.Length; i++)
        {
            Material mat = (Material)objs[Random.Range(0, i)];
            RenderSettings.skybox = mat;
        }
        RenderSettings.ambientLight = new Color(Mathf.PerlinNoise(0f, 255f), Mathf.PerlinNoise(0f, 255f), Mathf.PerlinNoise(0f, 255f));
        RenderSettings.ambientIntensity = Random.Range(0f, 2f);
        Time.timeScale = Random.Range(0.5f, 1f);
    }
}
#endif