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
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void Run()
    {
        if(Mathf.Abs(forwardInput) > inputDelay)
        {
            //move
            rBody.velocity = transform.forward * forwardInput * ForwardVelo;
            charAnimator.SetBool("isMoving", true);
        }
        else
        {
            //zero velo
            rBody.velocity = Vector3.zero;
            charAnimator.SetBool("isMoving", false);
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(RotateVelo * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }
}
