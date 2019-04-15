using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int Health { get; set; }
    Animator m_Animator;
    Camera2DFollow camera = new Camera2DFollow();
    public TextMeshProUGUI coinAmountText;

    private bool canMelee = true;

    public Vector3 startPosition = new Vector3(-3f, -3.27f, 0f);

    public AudioSource MeleeAudioSource;
    public AudioSource GameManagerAudioSource;

    public AudioClip generalAudioClip;
    public AudioClip russianAudioClip;

    public static float timer;
    public TextMeshProUGUI timerText;

    public static int amountCollected;

    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera2DFollow>();

        //This gets the Animator, which should be attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();

        this.Health = 1;
    }

    public static void ResetTimer()
    {
        timer = 0;
        Debug.Log("Timer Reset");
    }

    //Stop Timer
    public void StopTimer()
    {
        //Stop Timer Here

        Debug.Log("Timer Stopped");
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "lastdoor")
        {
            SceneManager.LoadScene("Credits");
        }

        if (col.gameObject.tag == "die")
        {
            amountCollected = 0;
            ResetTimer();
            Debug.Log("die");
            this.transform.position = startPosition;

            //Camera thing position
            camera.transform.position = startPosition;
        }

        if (col.gameObject.tag == "enemy")
        {
            camera.transform.position = startPosition;
        }

        if (col.gameObject.tag == "general")
        {
            m_Animator.Play("gen_player_idle", 0, 0f);
            Debug.Log("inGeneral");
            m_Animator.SetBool("isInGB", false);
            m_Animator.SetBool("isInFrance", false);
            m_Animator.SetBool("isInRussia", false);
            GameManagerAudioSource.clip = generalAudioClip;
            GameManagerAudioSource.Play();
        }

        if (col.gameObject.tag == "france")
        {
            Debug.Log("inFrance");
            m_Animator.SetBool("isInFrance", true);
        }

        if (col.gameObject.tag == "gb")
        {
            Debug.Log("inGB");
            m_Animator.SetBool("isInGB", true);
        }

        if (col.gameObject.tag == "russia")
        {
            Debug.Log("inRussia");
            m_Animator.SetBool("isInRussia", true);

            if (GameManagerAudioSource.clip != russianAudioClip)
            {
                GameManagerAudioSource.Stop();
                GameManagerAudioSource.clip = russianAudioClip;
                GameManagerAudioSource.Play();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "coin")
        {
            amountCollected = Int32.Parse(coinAmountText.text) + 1;
            coinAmountText.text = amountCollected + "";
            col.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("coin pickup");
            Destroy(col.GetComponent<SpriteRenderer>());
            Destroy(col.GetComponent<CircleCollider2D>());
            Destroy(col.gameObject, 0.5f);
        }

        if (GameObject.FindGameObjectWithTag("meleeweapon").GetComponent<BoxCollider2D>().IsTouching(col) &&
            col.gameObject.tag == "enemy")
        {
            /* Weapon */
            Debug.Log("Something here");
            col.gameObject.GetComponent<AudioSource>().Play();
            Destroy(col.GetComponent<SpriteRenderer>());
            Destroy(col.GetComponent<BoxCollider2D>());
            Destroy(col.gameObject, 0.5f);
        }
    }


    public void addHealth(int health)
    {
        if (health == 1)
        {
            this.Health += health;
        }
        else
        {
            //Do Nothing cause we have 2 hp already
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + (int) timer;
        StaticCredits.time = (int) timer;
        StaticCredits.coinsCollected = (int) amountCollected;
        Debug.Log(timer);
        if (Input.GetKeyDown(KeyCode.B) && !GetComponent<Animator>().GetBool("isInRussia"))
        {
            Debug.Log("Should melee attack");
            MeleeAudioSource.Play();
            Melee();
        }
    }

    void Melee()
    {
        // melee logic
        if (canMelee)
        {
            canMelee = false;
            GameObject.FindGameObjectWithTag("meleeweapon").GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Animator>().SetBool("isAttacking", true);
            //GetComponent<Animator>().SetTrigger("isAttacking");
            StartCoroutine(WaitForNextMeleeHit());
        }
    }

    IEnumerator WaitForNextMeleeHit()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.3f);
        print(Time.time);
        GetComponent<Animator>().SetBool("isAttacking", false);
        canMelee = true;
        GameObject.FindGameObjectWithTag("meleeweapon").GetComponent<BoxCollider2D>().enabled = false;
    }
}