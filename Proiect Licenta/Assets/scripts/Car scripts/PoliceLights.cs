using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour {
    public Renderer redSignal;
    public Renderer blueSignal;
    public Material redON;
    public Material redOFF;
    public Material blueON;
    public Material blueOFF;

    void Update () {
        redSignal.material = redON;
        blueSignal.material = blueON;
        float floor = 0f;
        float ceiling = 0.6f;
        float floor2 = 0.2f;
        float emission1 = floor + Mathf.PingPong(Time.time * 3f, ceiling - floor);
        float emission2 = floor + Mathf.PingPong(Time.time * 3f, ceiling - floor2);
        redSignal.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission1);
        blueSignal.material.SetColor("_EmissionColor", new Color(1f, 1f, 1) * emission2);
    }
}
