using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextHints : MonoBehaviour
{
    Text hinter;
    float timer = 0;
    float limit = 3;

    // Start is called before the first frame update
    void Start()
    {
        hinter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hinter.enabled==true)
        {
            timer += Time.deltaTime;
            if (timer >= limit)
                hinter.enabled = false;
        }
    }

  public void  DisplayHint(string hint)
    {
        hinter.text = hint;
        hinter.enabled = true;
        timer = 0;
    }
}
