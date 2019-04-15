using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public AudioClip jumpAudioClip;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
            animator.SetBool("Jump", true);
            GetComponent<AudioSource>().clip = jumpAudioClip;
            //if no audio file is playing
            if (!animator.GetBool("Jump"))
            {
                Debug.Log("audio play");
                GetComponent<AudioSource>().Play();
            }
           
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch = true;
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            crouch = false;
            animator.SetBool("Crouch", false);
        }


    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
        Debug.Log("landed");
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}