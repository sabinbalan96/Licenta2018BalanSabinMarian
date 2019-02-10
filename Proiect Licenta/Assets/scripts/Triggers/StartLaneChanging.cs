using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLaneChanging : MonoBehaviour {

    public GameObject displayMessage;
    public GameObject displayPanel;
    public GameObject displayMessage2;
    public GameObject displayPanel2;
    public GameObject indicatorsToDisplay;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            displayMessage.GetComponent<Text>().text = "Schimba banda urmarind indicatiile verzi!";
            displayPanel.SetActive(true);
            displayMessage2.GetComponent<Text>().text = "Nu uita sa semnalizezi pe tot parcurusul manevrei!";
            displayPanel2.SetActive(true);
            indicatorsToDisplay.SetActive(true);
            StartCoroutine(TurnOff());
        }
    }
    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(3);
        displayPanel.SetActive(false);
        displayPanel2.SetActive(false);
    }
}
