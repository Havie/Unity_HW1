using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{

    public Transform start;
    public Transform end;
    float speed = 0.3f;
    float elapsedTime = 0;
    public float weight;
    private float tripTime=3;

    private bool delay;



    // Update is called once per frame
    void Update()
    {
        //CNTRL+K + CNTRL +C / U  to comment uncomment
        //WILD Trig Code to do a lerp....?! How does it work
        //weight = Mathf.Cos(elapsedTime * speed * 2 * Mathf.PI) * 0.5f + 0.5f;
        //transform.position = start.position * weight + end.position * (1 - weight);
        //elapsedTime += Time.deltaTime;

        if (transform.position == end.position)
            swap();

        if (!delay)
        {
            transform.position = Vector3.Lerp(start.position, end.position, speed * elapsedTime % tripTime);
            elapsedTime += Time.deltaTime;
        }
    }

    public void swap()
    {
        delay = true;
        Transform tmp = start;
        start = end;
        end = tmp;
        elapsedTime = 0;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        delay = false;
    }
}
