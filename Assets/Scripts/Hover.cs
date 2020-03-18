using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    private float HoverForce = 25f;

    private void OnTriggerStay(Collider other)
    {
       // Debug.Log("I AM" + this.gameObject + "   collider is:" + other.gameObject);
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * HoverForce, ForceMode.Acceleration);
    }
}
