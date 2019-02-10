using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessTrigger : MonoBehaviour {

    public GameObject canvas;
    public GameObject triggerToDeactivate;
    public GameObject panelToDeactivate;
    public GameObject message;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            canvas.SetActive(true);
            StartCoroutine(Countdown());
            if (GlobalVariables.player_correct_signal) {
                GlobalVariables.maneuver_counter++;
                GlobalVariables.correct_maneuver_counter++;
                GlobalVariables.total_all++;
                GlobalVariables.total_correct++;
                message.GetComponent<Text>().text = "Felicitari!\nAi exectuat manevra corect!";
            }
            else
            {
                message.GetComponent<Text>().text = "Din pacate nu ai semnalizat corespunzator!";
                GlobalVariables.total_all++;
                GlobalVariables.maneuver_counter++;
            }
            triggerToDeactivate.SetActive(false);
            panelToDeactivate.SetActive(false);
            GlobalVariables.player_correct_signal = true;
            Debug.Log(GlobalVariables.player_correct_signal);
        }
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);
    }
}
