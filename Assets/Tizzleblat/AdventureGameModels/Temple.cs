using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temple : MonoBehaviour
{

    public Animator animController;

    public GameObject Player;


   public void Clicked()
    {
        animController.SetTrigger("doOpen");
    }
}
