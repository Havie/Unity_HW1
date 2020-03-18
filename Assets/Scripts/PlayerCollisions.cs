using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(this.transform.position, transform.forward, out hit, 5 );
        if(hit.collider)
        {
            if(hit.collider.gameObject.tag.Equals("PickUp"))
            {
                Debug.Log("Found:" + hit.collider.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Platform"))
        {
            transform.parent = other.transform;
            transform.parent.GetComponent<PlatformMover>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Platform"))
        {
            transform.parent = other.transform;
            transform.parent.GetComponent<PlatformMover>().enabled = false;
        }
    }
}
