using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightViolation : MonoBehaviour {

    public GameObject canvas;
    public GameObject continueButton;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {

            if (GlobalVariables.is_green==false)
            {
                canvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void Continue()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }
}
