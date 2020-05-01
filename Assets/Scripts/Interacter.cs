using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Interacter : MonoBehaviour
{
    public Texture2D cursor1;
    public Texture2D cursor2;

    private PlayerCollisions ps;
    private Transform playerCamera;
    private float maxDis = 12;


    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = player.transform;
        ps = player.GetComponent<PlayerCollisions>();
        print("started for " + this.gameObject.name);
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

    private void OnMouseDown()
    {
        print("Mouse down " + this.gameObject.tag);
        if (withinRange())
        {
            if(this.gameObject.tag.Equals("Rock"))
            {
                if (ps)
                    ps.Rock(this.gameObject);
            }
            if (this.gameObject.tag.Equals("Key"))
            {
                if (ps)
                    ps.Key(this.gameObject);
            }
            else if (this.gameObject.tag.Equals("Chest"))
            {
                if (ps)
                    ps.Chest(this.gameObject);
            }
            else if (this.gameObject.tag.Equals("Flower"))
            {
                if (ps)
                    ps.Flower(this.gameObject);
            }
        }
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
