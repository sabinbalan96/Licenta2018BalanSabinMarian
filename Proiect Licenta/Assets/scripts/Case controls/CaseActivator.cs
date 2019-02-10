using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseActivator : MonoBehaviour
{

    public GameObject caseToActivate;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            caseToActivate.SetActive(true);
        }
    }
}
