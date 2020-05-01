using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class PlayerCollisions : MonoBehaviour
    {

        public UITextHints hints;
        public BatteryCollect bc;

        // Start is called before the first frame update
        void Start()
        {
            bc = GameObject.FindGameObjectWithTag("BatteryUI").GetComponent<BatteryCollect>();
            hints = GameObject.FindGameObjectWithTag("TextHints").GetComponent<UITextHints>();

        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            Physics.Raycast(this.transform.position, transform.forward, out hit, 5);
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag.Equals("PickUp"))
                {
                   // Debug.Log("Found:" + hit.collider.gameObject);
                }
            }
        }

        public void OnTriggerEnter(Collider other)
        {
           // Debug.Log("Entered with " + other.gameObject);

            if (other.tag.Equals("Platform") && bc.juice >= 4)
            {
                //transform.parent = other.transform;
                // transform.parent.GetComponent<PlatformMover>().enabled = true;
                PlatformMover pm = other.GetComponent<PlatformMover>();
                if (pm == null)
                    Debug.LogWarning("why is this null?");
                other.GetComponent<PlatformMover>().enabled = true;
                this.transform.SetParent(other.transform);

                Debug.LogWarning("Turn on:" +other.name);
            }
            else
                hints.DisplayHint("Platform needs 4 juice");
        }

        private void OnTriggerExit(Collider other)
        {
           // Debug.Log("Exit with " + other.gameObject);

            if (other.tag.Equals("Platform"))
            {
                //transform.parent = other.transform;
                //transform.parent.GetComponent<PlatformMover>().enabled = false;
                other.GetComponent<PlatformMover>().enabled = false;
                this.transform.SetParent(null);

                Debug.LogWarning("Turn off:" + other.name);
            }
        }
    }
}