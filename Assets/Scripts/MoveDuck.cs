using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuck : MonoBehaviour
{
    [SerializeField]
    GameObject _TargetDuck;
    [SerializeField]
    Vector3 _VectorToTarget;
    float _DuckSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _VectorToTarget = (_TargetDuck.transform.position - transform.position);
       // transform.position = transform.position + _VectorToTarget;

        _VectorToTarget = _VectorToTarget.normalized * _DuckSpeed;


    }

    // Update is called once per frame
    void Update()
    {
        float distanceBetweenDucks = Vector3.Distance(transform.position, _TargetDuck.transform.position);
        if (distanceBetweenDucks > 1)
        {
            _VectorToTarget = _VectorToTarget.normalized * _DuckSpeed;
            transform.LookAt(_TargetDuck.transform.position);
            // transform.position = transform.position + _VectorToTarget;

            //transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);

        }


        /** If dot product is 1, vectors coincide
        * If dot product is 0, vectors at right angle
        * If dot product is -1, vectors in opposite direction
        * Take 〖𝑐𝑜𝑠〗^(−1)(V · W) to get exact angle
         */
    }
}
