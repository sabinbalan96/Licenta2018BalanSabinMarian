using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLights : MonoBehaviour {

    public Renderer brakelightLeft;
    public Renderer brakelightRight;
    public Renderer signalLeft;
    public Renderer signalRight;
    public Material brakelightON;
    public Material brakelightOff;
    public Material signalON;
    public Material signalOff;

    private bool signalRightON = false;
    private bool signalLeftON = false;

	void Update () {
        //adaptare dupa tutorialele video realizate de Aaron Hibberd "https://www.youtube.com/watch?v=kN7Rx3uPBuU&t=614s"
        if (!GlobalVariables.self_driving)
        {

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space) || Input.GetKey("s"))
            {
                brakelightLeft.material = brakelightON;
                brakelightRight.material = brakelightON;
            }
            else
            {
                brakelightLeft.material = brakelightOff;
                brakelightRight.material = brakelightOff;
            }

            if (Input.GetKeyDown("q"))
            {
                if (signalLeftON)
                {
                    signalLeftON = false;
                    GlobalVariables.player_signal_left = false;
                    signalRight.material = signalOff;
                    signalLeft.material = signalOff;
                }
                else
                {
                    signalLeftON = true;
                    signalRightON = false;
                    GlobalVariables.player_signal_left = true;
                }
            }
            if (Input.GetKeyDown("e"))
            {
                if (signalRightON)
                {
                    signalRightON = false;
                    GlobalVariables.player_signal_right = false;
                    signalRight.material = signalOff;
                    signalLeft.material = signalOff;
                }
                else
                {
                    signalRightON = true;
                    signalLeftON = false;
                    GlobalVariables.player_signal_right = true;
                }
            }

            if (signalLeftON)
            {
                signalLeft.material = signalON;
                signalRight.material = signalOff;
                signalLeftON = true;
                signalRightON = false;
                float floor = 0f;
                float ceiling = 1f;
                float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);
                signalLeft.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
            }
            if (signalRightON)
            {
                signalRight.material = signalON;
                signalLeft.material = signalOff;
                signalLeftON = false;
                signalRightON = true;
                float floor = 0f;
                float ceiling = 1f;
                float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);
                signalRight.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
            }
        }
        else
        {
            if (GlobalVariables.is_breaking)
            {
                brakelightLeft.material = brakelightON;
                brakelightRight.material = brakelightON;
            }
            else
            {
                brakelightLeft.material = brakelightOff;
                brakelightRight.material = brakelightOff;
            }
        }
    }
}
