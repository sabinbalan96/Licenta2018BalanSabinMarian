using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    // Use this for initialization
    public void Restart()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
        GlobalVariables.self_driving = true;
        GlobalVariables.is_green = false;
        GlobalVariables.collision_detected = false;
        GlobalVariables.player_signal_right = false;
        GlobalVariables.player_signal_left = false;
        GlobalVariables.player_correct_signal = true;
        GlobalVariables.is_breaking = false;
        GlobalVariables.total_all = 0;
        GlobalVariables.total_correct = 0;
        GlobalVariables.maneuver_counter = 0;
        GlobalVariables.correct_maneuver_counter = 0;
        GlobalVariables.question_counter = 0;
        GlobalVariables.correct_question_counter = 0;
        GlobalVariables.menu_displayed = true;
}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            Restart();
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(3);
        //canvas.SetActive(false);
    }
}
