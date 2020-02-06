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

    float OrbitSpeed=5f;

    // Start is called before the first frame update
    void Start()
    {
        offsetV = target.position - transform.position;
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
                _varX += Input.GetAxis("Mouse X")* OrbitSpeed;
                _varY -= Input.GetAxis("Mouse Y")* OrbitSpeed;


                _varY= Mathf.Clamp(_varY, -10f, 60f);

                Debug.Log("(X): " + (_varX));


             target.transform.eulerAngles = new Vector3(_varY,_varX, 0);

            }
        }
    }
}
