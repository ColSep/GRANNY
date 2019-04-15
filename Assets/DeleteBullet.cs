using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bulletboss")
        {
            Debug.Log("SHOULD DELETE BULLET");
            Destroy(col.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}