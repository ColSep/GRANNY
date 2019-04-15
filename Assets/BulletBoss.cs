using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public float speed = 0.5f;

    public Rigidbody2D rb;

    private GameObject player;

    private GameObject camera;

    void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //fly forward 
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Debug.Log("1:" + (player.transform.position.x - gameObject.transform.position.x));
        if ((player.transform.position.x - gameObject.transform.position.x) > 42f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        //bullet hits something
        if (hitInfo.gameObject.tag == "player")
        {
            Debug.Log("player should be dead from a bullet collision");
            player.transform.position = new Vector3(130f, 100f, 0f);
        }

        if (GameObject.FindGameObjectWithTag("boss").transform.position.x - gameObject.transform.position.x > 30f)
        {
            //bullet to far away so stop rendering
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("player should be dead from a bullet on trigger");
            Debug.Log("Trigger Enemy");
            Debug.Log("HIT ENEMY ");
            camera.transform.position = new Vector3(126f, -1.09f, 0f);
            player.transform.position = new Vector3(126f, -1.09f, 0f);
        }
    }

    void DestroyBoss(GameObject bossObject)
    {
        Debug.Log("Boss Destroyed " + BossScript.bosshp);
        Destroy(bossObject.gameObject);
        Destroy(gameObject);
    }
}