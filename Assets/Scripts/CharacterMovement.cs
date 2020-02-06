using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject Character;
    public float inputDelay = 0.1f;
    public float ForwardVelo = 12;
    public float RotateVelo = 70f;

    public Animator charAnimator;

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput,turnInput;


    public Vector3 location;




    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation;
        rBody = GetComponent<Rigidbody>();
        if (!rBody)
            Debug.LogError("No Rigidbody found on Character");

        charAnimator = GetComponent<Animator>();
        if (!charAnimator)
            Debug.LogError("No Animator??");

        forwardInput = 0;
        turnInput = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Turn();
        
    }

    private void FixedUpdate()
    {
        Run();
    }

    public Quaternion getTargetRotation()
    {
        return targetRotation;
    }

    void GetInput()
    {
        turnInput = Input.GetAxis("Vertical");
        forwardInput = Input.GetAxis("Horizontal");
    }

    void Run()
    {

        
         Vector3 move = new Vector3(forwardInput, 0, turnInput).normalized;
         move = move * ForwardVelo;
         rBody.velocity = move;

        if(move != Vector3.zero)
        {
            charAnimator.SetBool("isMoving", true);
            transform.forward = move;
        }
        else
            charAnimator.SetBool("isMoving", false);

        /*
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //move
            Vector3 change= (transform.forward * forwardInput * ForwardVelo);
            change.y = rBody.velocity.y;
            rBody.velocity = change;

            charAnimator.SetBool("isMoving", true);
        }
        else if (Mathf.Abs(turnInput) > inputDelay)
        {
            //move
            Vector3 change = (transform.right * turnInput * ForwardVelo);
            change.y = rBody.velocity.y;
            rBody.velocity = change;

            charAnimator.SetBool("isMoving", true);
        }
        else
        {
            //zero velo
           // rBody.velocity = Vector3.zero; // dont want to do or character falls weird
            charAnimator.SetBool("isMoving", false);
        }
        */


    }

    void Turn()
    {
       /* if (Mathf.Abs(turnInput) > inputDelay)
        {
          targetRotation *= Quaternion.AngleAxis(RotateVelo * turnInput * Time.deltaTime, Vector3.up);
        }
       transform.rotation = targetRotation;
       */
    }
}
