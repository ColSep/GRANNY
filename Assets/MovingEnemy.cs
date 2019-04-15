using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

// Note --> H: horizontal and V: vertical.

// Define two pairs of directions 


public class MovingEnemy : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(-3f, -3.27f, 0f);
    public GameObject player;

    public bool canJump = true;
    public int jumpChance = 750;
    public float jumpHeight = 300f;

    public Camera2DFollow camera = new Camera2DFollow();

    // Speed on both axes
    public float SpeedH = 0.3F;
    public float SpeedV = 0.0F;

    // Horizontal initial movement
    public DirectionH WayH = DirectionH.Right;

    // Vertical initial movement
    public DirectionV WayV = DirectionV.Up;

    // Maximum distance to cover
    // if equals -1; if does not turn back
    public float MaxMovingDistance = 5.0F;

    // Private
    private Transform PlatformTransform;
    private float WalkedDistanceH = 0.0F;
    private float WalkedDistanceV = 0.0F;
    private float ReferencePingPongHPosition;
    private float ReferencePingPongVPosition;
    private Vector3 InitialPlatformPosition;

    private GameObject target = null;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera2DFollow>();

        target = null;

        PlatformTransform = transform;

        // Saving of the initial Platform
        InitialPlatformPosition = PlatformTransform.position;

        // Calculation of the reference position h in case of rebound
        ReferencePingPongHPosition = PlatformTransform.position.x;

        // Calculation of the reference position v in case of rebound
        ReferencePingPongVPosition = PlatformTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Max distance h
        WalkedDistanceH = Math.Abs(PlatformTransform.position.x - ReferencePingPongHPosition);

        // Max distance v
        WalkedDistanceV = Math.Abs(PlatformTransform.position.y - ReferencePingPongVPosition);


        if (MaxMovingDistance != -1 && WalkedDistanceH >= MaxMovingDistance)
        {
            // turning back function
            if (WayH == DirectionH.Left)
            {
                WayH = DirectionH.Right;
                if (gameObject.tag != "boss")
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else
            {
                WayH = DirectionH.Left;
                if (gameObject.tag != "boss")
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }

            // Update of the horizontal position
            ReferencePingPongHPosition = PlatformTransform.position.x;
        }

        //Same but in axe Y
        if (MaxMovingDistance != -1 && WalkedDistanceV >= MaxMovingDistance)
        {
            if (WayV == DirectionV.Up)
            {
                WayV = DirectionV.Down;
            }
            else
            {
                WayV = DirectionV.Up;
            }

            ReferencePingPongVPosition = PlatformTransform.position.y;
        }

        // H movement
        if (WayH == DirectionH.Left)
        {
            SpeedH = -Math.Abs(SpeedH);
        }
        else
        {
            SpeedH = Math.Abs(SpeedH);
        }

        // V movement
        if (WayV == DirectionV.Down)
        {
            SpeedV = -Math.Abs(SpeedV);
        }
        else
        {
            SpeedV = Math.Abs(SpeedV);
        }

        // Moving the platform
        PlatformTransform.Translate(new Vector3(SpeedH, SpeedV, 0) * Time.deltaTime);

        if (canJump)
        {
            Random rnd = new Random();
            if (rnd.Next(jumpChance) == 5)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Trigger Enemy");
            Debug.Log("HIT ENEMY ");
            camera.transform.position = new Vector3(-3f, -3.27f, 0f);
            player.transform.position = new Vector3(-3f, -3.27f, 0f);
        }
    }
}