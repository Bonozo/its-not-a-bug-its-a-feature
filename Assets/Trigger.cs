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

            Player player = other.transform.root.gameObject.transform.root.GetComponent<Player>();
            if (player)
            {
                player.PlayerBonus(100000);
            }

            gameObject.SetActive(false);
        }
    }

}
