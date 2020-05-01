using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    private static Maze _instance;
    public GameObject spawnPoint;
    public GameObject TeleportLoc;


    public static Maze Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<Maze>();
            return _instance;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            StartMaze();
    }

    private void Awake()
    {
        if (_instance == null)
        {
            //if not, set instance to this
            _instance = this;
        }
        //If instance already exists and it's not this:
        else if (_instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
            return;
        }

    }


    public void StartMaze()
    {
        print("START MAZE!");
        var player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawnPoint.transform.position;
    }

   public void ClearedMaze()
    {
        print("Clear maze");
        var player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = TeleportLoc.transform.position;
    }
}
