using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Reset : MonoBehaviour
{
    public Vector3 PlayerStart;


    public GameObject _rock;
    public GameObject _key;
    public Chest _chest;
    public Flower _flower;
    public Temple _temple;
    public PlatformMover _platform;

    public GameObject[] _batteries;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        PlayerStart = player.transform.position;

    }

    // Update is called once per frame
   public void resetLevel()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerCollisions>().Reset();
        player.transform.position = PlayerStart;
        _rock.SetActive(true);
        _key.SetActive(true);
        _chest.ResetLid();
        _flower.ResetFlower();
        _temple.ResetStairs();
        _platform.resetPlat();

        var bc = GameObject.FindGameObjectWithTag("BatteryUI").GetComponent<BatteryCollect>();
        bc.resetJuice();

        foreach(GameObject g in _batteries)
        {
            g.SetActive(true);
        }

    }
}
