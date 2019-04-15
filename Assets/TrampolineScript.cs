using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D trampolineCollider2D)
    {

        if (trampolineCollider2D.tag == "Player")
        {
            //jump upwards
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1000f));
        }
    }
}