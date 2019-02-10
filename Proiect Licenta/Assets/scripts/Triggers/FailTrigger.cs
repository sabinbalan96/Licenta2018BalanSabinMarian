using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailTrigger : MonoBehaviour {

    public GameObject canvas;
   // public GameObject continueButton;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            canvas.SetActive(true);
            Time.timeScale = 0.3f;
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        //player.GetComponent<CarEngine>().enabled = true;
        //player.GetComponent<PlayerController>().enabled = false;
    }
}
