using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject objToActivate;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (tag == "Player")
        {
            if (objToActivate)
            {
                objToActivate.SetActive(true);
            }

            Player player = other.transform.root.gameObject.GetComponent<Player>();
            player.PlayerBonus(1000);
            //other.transform.localScale *= Random.Range(0.5f, 2.0f);

            //other.transform.localScale *= new Vector3(
            //    Random.Range(0.5f, 4.0f),
            //    Random.Range(0.5f, 4.0f),
            //    Random.Range(0.5f, 4.0f));
        }
    }

}
