using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseDeactivator : MonoBehaviour {

    public GameObject caseToDeactivate;
    public string tag;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == tag)
        {
             caseToDeactivate.SetActive(false);
        }
    }
}
