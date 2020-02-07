using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigOrbit : MonoBehaviour
{

    public Transform target;
    float _varX;
    float _varY;
    Vector3 offsetV;
    float offsetF;
    bool OrbitActive;

    float OrbitSpeed=50f;

    float _CameraDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        offsetV = target.position - transform.position;
        this.transform.LookAt(target);
    }

    
    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
            OrbitActive = true;
        else
            OrbitActive = false;

        if (OrbitActive)
        {
            //Rotate based on mouse X/Y
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _varX = Input.GetAxis("Mouse X")* OrbitSpeed;
                _varY = -Input.GetAxis("Mouse Y")* 2*OrbitSpeed;

                //Might need to normalize base of aspect ratio



                //_varY= Mathf.Clamp(_varY, -10f, 60f);

               //target.transform.eulerAngles = new Vector3(_varY,_varX, 0);

               

               transform.RotateAround(target.position, Vector3.up, _varX * Time.deltaTime);
               transform.RotateAround(target.position, Vector3.right, _varY * Time.deltaTime);

                transform.LookAt(target, Vector3.up);
            }

           
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {

            Debug.Log("(X): " + ("heard SCroll"));
            float ScrollAmnt = Input.GetAxis("Mouse ScrollWheel") ;

            //Scroll out faster the farther away we are
            ScrollAmnt *= (this._CameraDistance * 0.3f);

            this._CameraDistance += ScrollAmnt * -1f;

            //Wont get too close or too far from target
            this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 10f);

            // Compute viewing vector
            Vector3 viewVector = target.position - transform.position;
            float oldDist = viewVector.magnitude;
            viewVector.Normalize();

           

            //Need a check on the signs to be able to reverse
            if (oldDist > 3.5 && ScrollAmnt>0)
            {
                this.transform.localPosition += viewVector * 0.5f * Mathf.Sign(ScrollAmnt);
            }
            else if (oldDist < 20 && ScrollAmnt < 0)
            {
                this.transform.localPosition += viewVector * 0.5f * Mathf.Sign(ScrollAmnt);
            }
        }



    }
}
