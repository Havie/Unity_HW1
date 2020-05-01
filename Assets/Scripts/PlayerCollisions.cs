using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class PlayerCollisions : MonoBehaviour
    {

        public UITextHints hints;
        public BatteryCollect bc;


        public bool hasKey;
        public bool hasPotion;
        public bool has4Battery;
        public bool hasJewl;



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

            if (other.tag.Equals("Platform"))
            {
                if (bc.juice >= 4)
                {
                    //transform.parent = other.transform;
                    // transform.parent.GetComponent<PlatformMover>().enabled = true;
                    PlatformMover pm = other.GetComponent<PlatformMover>();
                    if (pm == null)
                        Debug.LogWarning("why is this null?");
                    StartCoroutine(PlatformDelay(other.gameObject));

                    Debug.LogWarning("Turn on:" + other.name);
                }
                else
                    hints.DisplayHint("Platform needs 4 juice", true);
            }
            else if (other.tag.Equals("Rock"))
            {
               //obsolete
            }
            else if (other.tag.Equals("Chest"))
            {
                //obsolete
            }
            else if (other.tag.Equals("Temple"))
            {
                print("Found Temple");
                if (hasJewl)
                {
                    //open stairs
                    other.GetComponent<Temple>().Clicked();
                    StartCoroutine(MazeDelay());
                }
                else
                    hints.DisplayHint("Need Jewl", true);
            }
            else if (other.tag.Equals("Maze"))
            {
                print("Found Exit");
                Maze.Instance.ClearedMaze();
                
            }
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

        IEnumerator PlatformDelay(GameObject other)
        {
            yield return new WaitForSeconds(1);
            other.GetComponent<PlatformMover>().enabled = true;
            this.transform.SetParent(other.transform);

        }
        IEnumerator MazeDelay()
        {
            yield return new WaitForSeconds(3.5f);
            Maze.Instance.StartMaze();
        }

        public void Rock(GameObject g)
        {
            print("Found Rock");
            g.SetActive(false);
            
        }
        public void Key(GameObject g)
        {
            hasKey = true;
            g.SetActive(false);
            hints.DisplayHint("You got Key!", false);
        }

        public void Chest(GameObject g)
        {
            print("Found Chest");
            if (hasKey)
            {
                //give potion
                g.GetComponent<Chest>().Clicked();
                hasPotion = true;
                hints.DisplayHint("You got potion!", false);
            }
            else
                hints.DisplayHint("Need Key", true);
        }
        public void Flower(GameObject g)
        {
            if(hasPotion)
            {
                hasJewl = true;
                g.GetComponent<Flower>().Clicked();
                hints.DisplayHint("You got Jewl!", false);
            }
            else
                hints.DisplayHint("Need Potion", true);
        }
    }
}