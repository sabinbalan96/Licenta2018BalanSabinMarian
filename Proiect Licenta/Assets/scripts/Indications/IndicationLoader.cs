using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicationLoader : MonoBehaviour {

    public GameObject indicationPanel;
    public GameObject indicationImage;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            indicationPanel.SetActive(true);
            indicationImage.SetActive(true);
        }
    }
}
