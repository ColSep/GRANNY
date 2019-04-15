using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public Rigidbody2D rb;


    public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //fly forward 
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //bullet hits something
        if (hitInfo.tag == "enemy" || hitInfo.tag == "boss")
        {
            if (hitInfo.tag == "enemy")
            {
                Destroy(hitInfo.gameObject);
                Destroy(gameObject);

                // Start effect bullet Hit
                //Instantiate(impactEffect, transform.position, transform.rotation);
            }
            else if (hitInfo.tag == "boss")
            {
                Destroy(gameObject);
                Debug.Log("Boss HP" + BossScript.bosshp);
                if (BossScript.bosshp > 0)
                {
                    BossScript.bosshp -= 1;


                    Debug.Log("BOSSHP: " + BossScript.bosshp);
                    if (BossScript.bosshp == 0)
                    {
                        DestroyBoss(hitInfo.gameObject);
                    }
                }
                else
                {
                    DestroyBoss(hitInfo.gameObject);
                }

                // Start effect bullet Hit
                //Instantiate(impactEffect, transform.position, transform.rotation);
            }
        }

        if (GameObject.FindGameObjectWithTag("Player").transform.position.x - gameObject.transform.position.x > 30f)
        {
            //bullet to far away so stop rendering
            Destroy(gameObject);
        }
    }

    void DestroyBoss(GameObject bossObject)
    {
        Debug.Log("Boss Destroyed " + BossScript.bosshp);
        Destroy(bossObject.gameObject);
        Destroy(gameObject);
        GameObject door = GameObject.FindGameObjectWithTag("door");
        door.SetActive(false);
    }
}