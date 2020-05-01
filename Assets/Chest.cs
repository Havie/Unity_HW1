using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public Animator lid;
    public GameObject key;
    public GameObject vial;



   public void Clicked()
    {
        lid.SetTrigger("doOpen");
        key.SetActive(true);
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        key.SetActive(false);
        vial.SetActive(false);
    }
}
