using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpForce = 500.0f;
    public float pushForce = 500.0f;
    public float hp = 100.0f;
    public Rigidbody rigidBody;
    public GameObject pfxPrefab;
    public GameObject xploPrefab;
    public GameplayMgr gameplayMgr;
    public CameraController cameraController;
    public Vector2 bounds;
    public AudioSource hitSfx;
    public AudioSource bonusSfx;

    private MeshRenderer renderObject;
    private GameObject pfxAttached;
    private float Score = 0.0f;
	// Use this for initialization
	void Start ()
    {
        renderObject = GetComponent<MeshRenderer>();
/*
        if (pfxPrefab)
        {
            pfxAttached = Instantiate(pfxPrefab, gameObject.transform.position, Quaternion.AngleAxis(  0.0f, Vector3.up) );
            pfxAttached.transform.localScale *= 0.5f;
            pfxAttached.transform.parent = gameObject.transform;
            pfxAttached = Instantiate(pfxPrefab, gameObject.transform.position, Quaternion.AngleAxis( 90.0f, Vector3.up));
            pfxAttached.transform.localScale *= 0.5f;
            pfxAttached.transform.parent = gameObject.transform;
            pfxAttached = Instantiate(pfxPrefab, gameObject.transform.position, Quaternion.AngleAxis(180.0f, Vector3.up));
            pfxAttached.transform.localScale *= 0.5f;
            pfxAttached.transform.parent = gameObject.transform;
            pfxAttached = Instantiate(pfxPrefab, gameObject.transform.position, Quaternion.AngleAxis(270.0f, Vector3.up));
            pfxAttached.transform.localScale *= 0.5f;
            pfxAttached.transform.parent = gameObject.transform;
        }
*/
    }

    void UpdateScore()
    {
        if (rigidBody.velocity.magnitude > GameplayMgr.veloThresh)
            return;

        Score += -rigidBody.velocity.y;

        DisplayScore();
    }

    void DisplayScore()
    {
        gameplayMgr.SetScore((int)Score);
    }

    void TakeDamage(float dmg)
    {
        hp -= dmg;
        if (hp < 0.0f)
            hp = 0.0f;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            JankSound.jankout();
            rigidBody.AddForce(new Vector3(0.0f, jumpForce, 0.0f));
        }

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(new Vector3(0.0f, 0.0f, pushForce));// (gameObject.transform.forward * 50.0f );
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddForce(new Vector3(0.0f, 0.0f, -pushForce));//(gameObject.transform.forward * -50.0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(new Vector3(-pushForce, 0.0f, 0.0f));//(gameObject.transform.right * -50.0f);
            //rigidBody.AddTorque(new Vector3(0.0f, -2.0f, 0.0f));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(new Vector3(pushForce, 0.0f, 0.0f));//(gameObject.transform.right * 50.0f);
            //rigidBody.AddTorque(new Vector3(0.0f, 2.0f, 0.0f));
        }
        /*
                if( rigidBody.velocity.magnitude < 0.1f )
                {
                    if(pfxAttached.activeSelf==false)
                    pfxAttached.SetActive(true);
                }
                else
                {
                    if (pfxAttached.activeSelf == false)
                        pfxAttached.SetActive(true);
                }
        */


        UpdateInbounds();
        UpdateScore();

        gameplayMgr.SetHP((int)hp);

    }

    void UpdateInbounds()
    {
        Vector3 playerPos = rigidBody.transform.position;
        float pushForce = 3000.0f;

        if (playerPos.x < bounds.x * -0.5f)
        {
            rigidBody.AddForce(new Vector3(pushForce, 0.0f, 0.0f));
        }

        if (playerPos.x > bounds.x * 0.5f)
        {
            rigidBody.AddForce(new Vector3(-pushForce, 0.0f, 0.0f));
        }

        if (playerPos.z < bounds.y * -0.5f)
        {
            rigidBody.AddForce(new Vector3(0.0f, 0.0f, pushForce));
        }

        if (playerPos.z > bounds.y * 0.5f)
        {
            rigidBody.AddForce(new Vector3(0.0f, 0.0f, -pushForce));
        }
    }

    private IEnumerator Flash()
    {
        renderObject.material.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        renderObject.material.color = Color.white;
    }

    public void PlayerHit(float dmg)
    {
        hitSfx.Play();

        if (hp <= 0.0f)
            return;

        TakeDamage(dmg);

        if (hp > 0.0f)
        {
            // hit
            if(pfxPrefab)
            {
                GameObject xplogo = Instantiate(pfxPrefab, rigidBody.transform.position, Quaternion.identity);
                xplogo.transform.localScale *= 3.0f;
            }
        }
        else
        {
            // die
            if (pfxPrefab)
            {
                GameObject xplogo = Instantiate(pfxPrefab, rigidBody.transform.position, Quaternion.identity);
                xplogo.transform.localScale *= 3.0f;
            }

            Destroy(gameObject);
            cameraController.GameOver();
            gameplayMgr.GameOver();
        }

    }

    public void PlayerBonus( int bonus )
    {
        Score += bonus;

        DisplayScore();

        bonusSfx.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        string tag = other.tag;
    }



}
