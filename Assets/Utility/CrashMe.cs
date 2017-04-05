using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrashMe : MonoBehaviour
{
    public void Awake()
    {
        GameObject go = GameObject.Instantiate(gameObject, Vector3.back, Quaternion.identity);
    }

    public void Crash()
    {
//#if !UNITY_EDITOR
        GameObject crashObj = Instantiate(gameObject);
//#endif
    }
}
