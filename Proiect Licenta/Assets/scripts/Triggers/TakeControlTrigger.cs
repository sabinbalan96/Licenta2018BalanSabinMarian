using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeControlTrigger : MonoBehaviour
{
    public GameObject message;
    public GameObject canvas;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            canvas.SetActive(true);
            StartCoroutine(Countdown());
            //caseToActivate.SetActive(true);
            if (GlobalVariables.self_driving)
            {
                message.GetComponent<Text>().text = "Tocmai ai preluat controlul!";
                GlobalVariables.self_driving = false;
            }
            else
            {
                message.GetComponent<Text>().text = "Controlul masinii este acum automat!";
                GlobalVariables.self_driving = true;
            }
        }
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(2);
        canvas.SetActive(false);
    }
}
