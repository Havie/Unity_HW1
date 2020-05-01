using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vial : MonoBehaviour
{
    public GameObject cap;
    public ParticleSystem water;
    public Animation animator;

    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        water.Stop();

    }

    public void Update()
    {
        if (test)
            PlayVial();
    }

    public void PlayVial()
    {
        test = false;
        // animator.enabled = true;
        animator.Play();
        StartCoroutine(waterDelay());
    }

    IEnumerator waterDelay()
    {
        yield return new WaitForSeconds(1);
        water.Play();
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

}
