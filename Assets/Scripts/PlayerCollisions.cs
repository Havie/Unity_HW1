using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public UITextHints hints;
    public BatteryCollect bc;

    // Start is called before the first frame update
    void Start()
    {
        bc = GameObject.FindGameObjectWithTag("BatteryUI").GetComponent<BatteryCollect>();
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
        Debug.Log("Entered with " + other.gameObject);

        if (other.tag.Equals("Platform") && bc.juice >= 4)
        {
            transform.parent = other.transform;
            transform.parent.GetComponent<PlatformMover>().enabled = true;
        }
        else
            hints.DisplayHint("Platform needs 4 juice");
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
