using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class playermov : MonoBehaviour
{
    // Start is called before the first frame update

    
    private float horizontalMove = 0f;
    private Transform PlayerTransform;

    float speed = 3.0f;

    public static float timer;
    public TextMeshProUGUI timerText;


    void Awake()
    {
        
        PlayerTransform = GetComponent<Transform>();
    }

    void Start()
    {
        
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

    //Start Timer
    public void StartTimer()
    {
        //Start Timer Here

        Debug.Log("Timer Started");
    }

    // Update is called once per frame
    void Update()
    {
        
        //horizontalMove = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
    }
    void FixedUpdate()
    {
       // PlayerTransform.position += new Vector3(horizontalMove,PlayerTransform.position.y,0);
    }
}
