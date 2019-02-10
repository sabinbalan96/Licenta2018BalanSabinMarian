using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject panel;
    public GameObject button;
    public GameObject secondsBox;
    public GameObject messageBox;
    public GameObject messageText;
    public float countdownValue = 15;
    private float currCountdownValue;
    private string msg;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            panel.SetActive(true);
            StartCoroutine(StartCountdown());
        }
    }
    public IEnumerator StartCountdown()
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0)
        {
           // Debug.Log("Countdown: " + currCountdownValue);
            secondsBox.GetComponent<Text>().text = currCountdownValue.ToString();
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        Time.timeScale = 0;
        msg = "Timpul a expirat! Mai mult noroc data viitoare!";
        messageText.GetComponent<Text>().text = msg;
        messageBox.SetActive(true);
        button.SetActive(true);
    }
}
