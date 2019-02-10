using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {

    bool isPaused = false;
    public GameObject canvas;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p") && !GlobalVariables.menu_displayed)
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                canvas.SetActive(false);
            }
            else
            {
                isPaused = true;
                Time.timeScale = 0;
                canvas.SetActive(true);
            }
        }

    }
}
