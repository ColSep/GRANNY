using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI timer;

    void Start()
    {
        coins.text = "Coins: " + StaticCredits.coinsCollected;
        timer.text = "Time: " + StaticCredits.time + " seconds";
    }

   
}
