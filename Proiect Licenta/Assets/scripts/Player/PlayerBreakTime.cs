using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreakTime : MonoBehaviour {
    public float seconds;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            GlobalVariables.is_breaking = true;
            StartCoroutine(Countdown());
        }
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(seconds);
        GlobalVariables.is_breaking = false;
    }
}
