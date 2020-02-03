using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 2, -4);
    public float xTilt = 15f;

    Vector3 destination = Vector3.zero;
    CharacterMovement charController;
    float rotateVelo = 0;


    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;




    // Start is called before the first frame update
    void Start()
    {
        setCameraTarget(target);
    }


    private void LateUpdate()
    {
        moveToTarget();

       if(Input.GetMouseButton(1))
        {
            LookAtTargetRMB();
            print("Down");
        }
       else
           lookAtTarget();



    }

    public void setCameraTarget(Transform t)
    {
        target = t;
        if (target != null)
        {
            if (target.GetComponent<CharacterMovement>())
            {
                charController = target.GetComponent<CharacterMovement>();
            }
            else
                Debug.LogError("Cameras target missing character controller");
        }
        else
            Debug.LogError("Camera has no target");
    }

    void moveToTarget()
    {
        destination = charController.getTargetRotation() * offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }

    void lookAtTarget()
    {
        //transform.LookAt(target);

        //better lerp?
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVelo, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }

    void LookAtTargetRMB()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

}
