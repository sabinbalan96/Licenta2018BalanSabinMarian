using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestionTriggerTest : MonoBehaviour {

    public GameObject trigger;
    public GameObject canvas;
    public GameObject question;
    public GameObject ans1_text;
    public GameObject ans2_text;
    public GameObject ans3_text;
    public GameObject ans1_toggle;
    public GameObject ans2_toggle;
    public GameObject ans3_toggle;
    public GameObject button_text;
    public GameObject rightAnswerAnnouncer;
    public GameObject wrongAnswerAnnouncer;

    string path;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            QuestionInfo();
            button_text.GetComponent<Text>().text = "Raspunde";
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void QuestionInfo()
    {
        path = "questions/" + trigger.name + ".txt";
        System.IO.StreamReader file =
            new System.IO.StreamReader(path);
        question.GetComponent<Text>().text = file.ReadLine();
        ans1_text.GetComponent<Text>().text = file.ReadLine();
        ans2_text.GetComponent<Text>().text = file.ReadLine();
        ans3_text.GetComponent<Text>().text = file.ReadLine();
        GlobalVariables.ans1_value = file.ReadLine() == "1";  //converting string to bool
        GlobalVariables.ans2_value = file.ReadLine() == "1";
        GlobalVariables.ans3_value = file.ReadLine() == "1";
        file.Close();
    }

    public void Resume()
    {
        if (button_text.GetComponent<Text>().text == "Raspunde")
        {
            CheckAnswer();
            button_text.GetComponent<Text>().text = "Continua";
        }
        else
        { Time.timeScale = 1;
        canvas.SetActive(false);
        ans1_toggle.GetComponent<Toggle>().isOn = false;
        ans2_toggle.GetComponent<Toggle>().isOn = false;
        ans3_toggle.GetComponent<Toggle>().isOn = false;
        ans1_text.GetComponent<Text>().color = Color.white;
        ans2_text.GetComponent<Text>().color = Color.white;
        ans3_text.GetComponent<Text>().color = Color.white;
        rightAnswerAnnouncer.SetActive(false);
        wrongAnswerAnnouncer.SetActive(false);
        }
    }

    void CheckAnswer()
    {
        bool trueFlag = true;

        if (GlobalVariables.ans1_value)
        {
            if (GlobalVariables.answer1) ans1_text.GetComponent<Text>().color = Color.green;
            else
            {
                ans1_text.GetComponent<Text>().color = Color.yellow;
                trueFlag = false;
            }
        }
        else 
         {
            if (GlobalVariables.answer1)
            {
                ans1_text.GetComponent<Text>().color = Color.red;
                trueFlag = false;
            }
        }

        if (GlobalVariables.ans2_value)
        {
            if (GlobalVariables.answer2) ans2_text.GetComponent<Text>().color = Color.green;
            else
            {
                ans2_text.GetComponent<Text>().color = Color.yellow;
                trueFlag = false;
            }
        }
        else
        {
            if (GlobalVariables.answer2)
            {
                ans2_text.GetComponent<Text>().color = Color.red;
                trueFlag = false;
            }
        }

        if (GlobalVariables.ans3_value)
        {
            if (GlobalVariables.answer3) ans3_text.GetComponent<Text>().color = Color.green;
            else
            {
                ans3_text.GetComponent<Text>().color = Color.yellow;
                trueFlag = false;
            }
        }
        else
        {
            if (GlobalVariables.answer3)
            {
                ans3_text.GetComponent<Text>().color = Color.red;
                trueFlag = false;
            }
        }
        if (trueFlag)
        {
            rightAnswerAnnouncer.SetActive(true);
            GlobalVariables.total_all++;
            GlobalVariables.question_counter++;
            GlobalVariables.total_correct++;
            GlobalVariables.correct_question_counter++;
        }
        else
        {
            wrongAnswerAnnouncer.SetActive(true);
            GlobalVariables.total_all++;
            GlobalVariables.question_counter++;
        }
    }
}
