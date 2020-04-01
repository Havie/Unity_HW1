using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public Texture2D cursor1;
    public Texture2D cursor2;

    private Transform playerCamera;
    private float maxDis = 8;


    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void OnMouseEnter()
    {
        if(withinRange())
            Cursor.SetCursor(cursor2, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursor1, Vector2.zero, CursorMode.Auto);
    }


    public bool withinRange()
    {
        if (playerCamera)
        {
            if ((playerCamera.transform.position - this.transform.position).magnitude < maxDis)
                return true;
        }
        return false;
    }
}
