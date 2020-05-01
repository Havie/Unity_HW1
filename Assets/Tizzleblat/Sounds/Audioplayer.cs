using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioplayer : MonoBehaviour
{
    public static Audioplayer _instance;

    public AudioSource MusicController;
    public AudioSource SFXController;
    public AudioSource SFXController2;


    public AudioClip birds;
    public AudioClip inventoryItem;
    public AudioClip hint;


    public static Audioplayer Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<Audioplayer>();
            return _instance;
        }
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
    // Start is called before the first frame update
    void Start()
    {
        SFXController.clip = birds;
        SFXController.Play();
        SFXController.loop = true;
    }

    public void PlayHint()
    {
        SFXController2.Stop();
        SFXController2.clip = hint;
        SFXController2.Play();
    }
    public void PlayInventory()
    {
        SFXController2.Stop();
        SFXController2.clip = inventoryItem;
        SFXController2.Play();
    }
}
