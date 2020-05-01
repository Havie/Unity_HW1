using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public Animator anim;
    public GameObject jewl;
    public GameObject vial;

    public void Clicked()
    {
        vial.SetActive(true);
        vial.GetComponent<Vial>().PlayVial();
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.35f);
        anim.SetTrigger("doRevive");
        jewl.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        jewl.SetActive(false);
    }

    public void ResetFlower()
    {
        anim.SetTrigger("doReset");
        vial.SetActive(false);
    }
}
