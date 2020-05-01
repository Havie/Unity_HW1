using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryCollect : MonoBehaviour
{
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;

    Image BatteryImg;
    Interacter interacter;

   public int juice = 3;

    // Start is called before the first frame update
    void Start()
    {
        BatteryImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (juice == 1)
            BatteryImg.sprite = s1;
        else if (juice == 2)
            BatteryImg.sprite = s2;
        else if (juice == 3)
            BatteryImg.sprite = s3;
        else if (juice == 4)
            BatteryImg.sprite = s4;
        else if (juice == 5)
            BatteryImg.sprite = s5;

        if (Input.GetKeyDown(KeyCode.I))
            increaseJuice(1);
    }

    public void increaseJuice(int num)
    {
        if (juice + num > 5)
            juice = 5;
        else if (juice + num < 1)
            juice = 1;
        else
            ++juice;
    }

    public int getJuice()
    {
        return juice;
    }
}
