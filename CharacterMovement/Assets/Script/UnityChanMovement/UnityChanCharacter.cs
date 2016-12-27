using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanCharacter : MonoBehaviour
{

    const string IS_UMATO = "isUmato";
    const string SPEED = "speed";
    const string IS_JUMPING = "isJumping";
    const string IS_SLIDING = "isSliding";

    Animator animator;

    Transform trans;

    Vector3 currentDirection;
    Vector3 inputVector;

    float animatorSpeed;
    float currentSpeed;

    float speedBeforeJump;

    float accel;

    public Transform cameraCenter;

    public float timeToMaxVel;
    public float speed;
    public float decelSpeed;
    public float rotationSpeed;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        // Assign the current direction from the taken input and normalize
        currentDirection = inputVector;
        currentDirection = Vector3.Normalize(currentDirection);

        bool isMoving = currentDirection.magnitude > 0;

        // Calculate the acceleration of the character
        {
            if (isMoving)
            {
                accel += Time.deltaTime;

                if (accel > timeToMaxVel)
                    accel = timeToMaxVel;

                animatorSpeed = accel / timeToMaxVel;
            }
            else
            {
                accel -= Time.deltaTime * decelSpeed;

                if (accel < 0)
                    accel = 0;

                animatorSpeed = accel / timeToMaxVel;
            }

            // Set the animator variable speed to currentSpeed
            animator.SetFloat(SPEED, animatorSpeed);

        }


        // Make the caracter look in the direction where he is walking
        if (isMoving)
            trans.rotation = Quaternion.Slerp(trans.rotation, Quaternion.LookRotation(currentDirection), Time.deltaTime * rotationSpeed);

        // Reset the input vector
        inputVector = Vector3.zero;

        // Update the position depending on the current state
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Umato") || animator.GetCurrentAnimatorStateInfo(0).IsTag("Slide"))
        {
            trans.position += trans.forward * speed * Time.deltaTime;
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
        {
            Vector3 baseVelocity = trans.forward * speed * Time.deltaTime;

            // If the character was running, maintain a certain velocity
            if (speedBeforeJump > 0)
                trans.position += trans.forward * speedBeforeJump * speed * Time.deltaTime;

            // Permit the character to move even with 0 initial velocity from ground
            else
            {
                trans.position += trans.forward * animatorSpeed * speed * Time.deltaTime * 0.5f;
            }
        }
        else
        {
            trans.position += trans.forward * animatorSpeed * speed * Time.deltaTime;
        }

    }

    // Disable the bool variable in the next frame (30fps)
    private IEnumerator DisableBoolNextFrame(string animParameter)
    {
        yield return new WaitForSeconds(0.033f);

        animator.SetBool(animParameter, false);
    }

    public void Umato()
    {
        animator.SetBool(IS_UMATO, true);
        StartCoroutine(DisableBoolNextFrame(IS_UMATO));
    }

    public void Slide()
    {
        animator.SetBool(IS_SLIDING, true);
        StartCoroutine(DisableBoolNextFrame(IS_SLIDING));
    }

    public void Jump()
    {
        animator.SetBool(IS_JUMPING, true);
        speedBeforeJump = animatorSpeed;
        StartCoroutine(DisableBoolNextFrame(IS_JUMPING));
    }

    public void MoveForward()
    {
        inputVector += cameraCenter.forward;
    }

    public void MoveRight()
    {
        inputVector += cameraCenter.right;
    }

    public void MoveLeft()
    {
        inputVector += -cameraCenter.right;

    }

    public void MoveBack()
    {
        inputVector += -cameraCenter.forward;

    }
}
