using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalCheck : MonoBehaviour {
    public bool shouldSignalRight; //false = should signal left
 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle" && GlobalVariables.player_correct_signal )
        {
            if (shouldSignalRight)
            {
                if (GlobalVariables.player_signal_right)
                {
                    GlobalVariables.player_correct_signal = true;
                }
                else
                {
                    GlobalVariables.player_correct_signal = false;
                }
            }
            else
            {
                if (GlobalVariables.player_signal_left)
                {
                    GlobalVariables.player_correct_signal = true;
                }
                else
                {
                    GlobalVariables.player_correct_signal = false;
                }
            }
            Debug.Log("player correct signal: "+GlobalVariables.player_correct_signal);
        }
    }
}
