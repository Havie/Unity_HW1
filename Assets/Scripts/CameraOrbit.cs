using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform Character;

    private Transform _xForm_Camera;
    private Transform _XForm_Parent;
    private Vector3 _LocalRotation;
    private float _CameraDistance = 10f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitivity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public bool OrbitActive;
    private bool test=true;

    void Start()
    {
        this._xForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
    }

   
    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
            OrbitActive = true;
        else
            OrbitActive = false;


        if(OrbitActive)
        {
            //Rotate based on mouse X/Y
            if(Input.GetAxis("Mouse X" ) !=0 || Input.GetAxis("Mouse Y")!=0)
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                //Clamp Y Rotation to horizion and not flipping over the top
                _LocalRotation.y = Mathf.Clamp(_LocalRotation.y, -10f, 70f);
            }
        }

        if (test)
        {

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                float ScrollAmnt = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

                //Scroll out faster the farther away we are
                ScrollAmnt *= (this._CameraDistance * 0.3f);


                this._CameraDistance += ScrollAmnt * -1f;

                //Wont get too close or too far from target
                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 10f);
            }


            //Actual Camera Rig Tranformations
            Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
            this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);
           // Debug.Log("This Happned");
            if (this._xForm_Camera.localPosition.z != this._CameraDistance * -1f)
            {
                this._xForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._xForm_Camera.localPosition.z, this._CameraDistance, Time.deltaTime * ScrollDampening));
                // this.transform.LookAt(Character);
                Debug.Log("Were In the IF");
            }

        }
    }
}
