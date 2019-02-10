using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case3Start : MonoBehaviour {

    public GameObject objectToActivate;
    public GameObject objectToActivate2;
    public GameObject objectToActivate3;
    public GameObject objectToActivate4;
    public GameObject objectToActivate5;
    public GameObject redColor;
    public GameObject greenColor;
    public GameObject yellowColor;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            yellowColor.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            greenColor.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            objectToActivate4.GetComponent<StaticSignal>().enabled = true;
            objectToActivate5.GetComponent<RearStaticSignal>().enabled = true;
            StartCoroutine(Countdown());
        }
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        yellowColor.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        redColor.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        objectToActivate.GetComponent<CarEngineNoLights>().enabled = true;
        objectToActivate2.GetComponent<CarEngineNoLights>().enabled = true;
        objectToActivate3.GetComponent<CarEngineNoLights>().enabled = true;
        yield return new WaitForSeconds(10);
        redColor.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        greenColor.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        GlobalVariables.is_green = true;
    }
}
