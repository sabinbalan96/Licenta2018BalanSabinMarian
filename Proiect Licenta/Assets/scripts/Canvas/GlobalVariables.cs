using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static bool answer1 = false; //chosen answer
    public static bool answer2 = false;
    public static bool answer3 = false;
    public static bool ans1_value = false; //correct answers
    public static bool ans2_value = false;
    public static bool ans3_value = false;
    public static int total_all = 0;
    public static int total_correct = 0;
    public static int maneuver_counter = 0;
    public static int correct_maneuver_counter = 0;
    public static int question_counter = 0;
    public static int correct_question_counter = 0;
    public static bool self_driving = true;
    public static bool is_green = false;
    public static bool collision_detected = false;
    public static bool player_signal_right = false;
    public static bool player_signal_left = false;
    public static bool player_correct_signal = true;
    public static bool is_breaking = false;
    public static bool menu_displayed = true;

    public void GetAnswer1(bool answer)
    {
        answer1 = answer;
    }
    public void GetAnswer2(bool answer)
    {
        answer2 = answer;
    }
    public void GetAnswer3(bool answer)
    {
        answer3 = answer;
    }
}
