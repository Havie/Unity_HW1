using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESCMenu : MonoBehaviour
{

    public GameObject ESC;
    public GameObject PauseMenu;

    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        ESC.SetActive(false);
        PauseMenu.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToggleEsc();
    }

    public void ToggleEsc()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            ESC.SetActive(true);
            PauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            ESC.SetActive(false);
            PauseMenu.SetActive(false);
        }
    }
}
