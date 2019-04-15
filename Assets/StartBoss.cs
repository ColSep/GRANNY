using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("SHOULD START BOSS");
        GameObject.FindGameObjectWithTag("boss").GetComponent<BossScript>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}