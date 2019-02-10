using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameTrigger : MonoBehaviour {

    public GameObject correctQuestions;
    public GameObject correctManeuver;
    public GameObject totalQuestions;
    public GameObject totalManeuver;
    public GameObject canvas;
    // Use this for initialization
    void Start () {
        correctQuestions.GetComponent<Text>().text = GlobalVariables.correct_question_counter.ToString();
        totalQuestions.GetComponent<Text>().text = GlobalVariables.question_counter.ToString();
        correctManeuver.GetComponent<Text>().text = GlobalVariables.correct_maneuver_counter.ToString();
        totalManeuver.GetComponent<Text>().text = GlobalVariables.maneuver_counter.ToString();
    }
    void Update()
    {
        correctQuestions.GetComponent<Text>().text = GlobalVariables.correct_question_counter.ToString();
        totalQuestions.GetComponent<Text>().text = GlobalVariables.question_counter.ToString();
        correctManeuver.GetComponent<Text>().text = GlobalVariables.correct_maneuver_counter.ToString();
        totalManeuver.GetComponent<Text>().text = GlobalVariables.maneuver_counter.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            canvas.SetActive(true);
            Time.timeScale = 0.5f;
        }
    }
}
