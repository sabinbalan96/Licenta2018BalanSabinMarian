using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnRoadManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject message;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "line")
        {
                message.GetComponent<Text>().text = "Circulatia pe contrasens este interzisa! Ai picat examenul!";
                canvas.SetActive(true);
                Time.timeScale = 0.3f;
        }
        if (other.tag == "margin")
        {
                message.GetComponent<Text>().text = "Ai parasit partea carosabila! Ai picat examenul!";
                canvas.SetActive(true);
                Time.timeScale = 0.3f;
        }
    }
}
