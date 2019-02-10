using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {


    public GameObject correctAnswers;
    public GameObject totalAnswers;

    void Start()
    {

    }
    void Update () {
    correctAnswers.GetComponent<Text>().text=GlobalVariables.total_correct.ToString();
    totalAnswers.GetComponent<Text>().text=GlobalVariables.total_all.ToString();
    }
}
