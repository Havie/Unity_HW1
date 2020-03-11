using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpLight : MonoBehaviour
{
    //https://www.youtube.com/watch?v=cD-mXwSCvWc
    private Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        newPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        PositionChanging();
    }

    void PositionChanging()
    {
        Vector3 PosA = new Vector3(-5, 4, 0);
        Vector3 PosB = new Vector3(5, 3, 0);

        if(Input.GetKeyDown(KeyCode.Q))
        {
            newPos = PosA;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            newPos = PosB;
        }

        transform.position = Vector3.Lerp(this.transform.position, newPos, Time.deltaTime);
    }
}
