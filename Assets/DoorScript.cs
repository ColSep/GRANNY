using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Door collision with:" + col);
        //bullet hits something
        if (col.gameObject.tag == "player")
        {
            StaticCredits.time = (int) PlayerScript.timer;
            StaticCredits.coinsCollected = (int) PlayerScript.amountCollected;
            SceneManager.LoadScene("Credits");
        }
    }
}