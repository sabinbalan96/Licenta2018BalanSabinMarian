using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEngine : MonoBehaviour {

    public GameObject objectToActivate;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            objectToActivate.GetComponent<CarEngineNoLights>().enabled = true;
        }	
	}
}
