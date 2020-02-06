using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    private CharacterMovement charController;

    //unused
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float rotateVelo = 0;

    public float RotationSpeed = 5.0f;
    public float lookSmooth = 0.09f;
    public float xTilt = 15f;



    // Start is called before the first frame update
    void Start()
    {
        setCameraTarget(target);
        offset = this.transform.position - target.position;

    }


    private void LateUpdate()
    {
        this.transform.position = target.position + offset;

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


    //unused
    void lookAtTargetLerp()
    {
        //transform.LookAt(target);

        //better lerp?
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVelo, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }


    //unused
    void LookAtTargetRMB()
    {
        //yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");
        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            Quaternion camTurnAngle =
             Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            offset = camTurnAngle * offset;
            transform.LookAt(target);
        
    }

}
