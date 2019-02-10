using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSignal : MonoBehaviour {

    public Renderer signal;
    public Material signalON;
    public Material signalOff;
    public int timeLeft;

    private float timer=0.0f;

    void Update () {
        timer += Time.deltaTime;
        float seconds = timer % 60;
        //Debug.Log(seconds);
        if (seconds < timeLeft)
        {
            signal.material = signalON;
            float floor = 0f;
            float ceiling = 1f;
            float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);
            signal.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
        }
        else
        {
            signal.material = signalOff;
        }
    }
}
