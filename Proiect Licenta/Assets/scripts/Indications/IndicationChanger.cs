using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicationChanger : MonoBehaviour {

    public GameObject indicationToRemove;
    public GameObject indicationToDisplay;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            indicationToRemove.SetActive(false);
            indicationToDisplay.SetActive(true);
        }
    }
}
