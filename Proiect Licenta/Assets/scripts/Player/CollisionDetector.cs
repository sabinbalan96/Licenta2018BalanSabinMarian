using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

    public GameObject canvas;
    public GameObject player;

	void Update () {
		if (GlobalVariables.collision_detected)
        {
            player.GetComponent<PlayerController>().enabled = false;
            canvas.SetActive(true);
            Time.timeScale = 0.4f;
        }
	}
}
