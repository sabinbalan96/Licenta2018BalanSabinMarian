using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject controls;
    public GameObject btnStart;
    public GameObject btnControls;
    public GameObject btnLvl1;
    public GameObject btnLvl2;
    public GameObject player;
    public GameObject score;

    bool active = false;
    bool canStart = true;
    Vector3 startPos;
    // Use this for initialization
    void Start()
    {
        startPos = player.transform.position;
        Time.timeScale = 0;
        btnLvl1.GetComponent<Image>().color = new Color(0, 255, 0);
    }

    public void StartButton()
    { if (canStart)
        {
            Time.timeScale = 1;
            menuPanel.SetActive(false);
            score.SetActive(true);
            controls.SetActive(false);
            GlobalVariables.menu_displayed = false;
        }
    }
    public void ControlsButtons()
    {
        
        if (active)
        {
            controls.SetActive(false);
            active = false;
            btnControls.GetComponent<Image>().color = new Color(245, 245, 245);
        }
        else
        {
            controls.SetActive(true);
            active = true;

            btnControls.GetComponent<Image>().color= new Color(0,255, 0);
        }
    }
    public void level1()
    {
        btnLvl1.GetComponent<Image>().color = new Color(0, 255, 0);
        btnLvl2.GetComponent<Image>().color = new Color(159, 159, 159);
        canStart = true;
        player.transform.position = startPos;
        Vector3 rotation = new Vector3(0, 180, 0);
        player.transform.eulerAngles = rotation;
    }
    public void level2()
    {
        btnLvl2.GetComponent<Image>().color = new Color(0, 255, 0);
        btnLvl1.GetComponent<Image>().color = new Color(159, 159, 159);
        canStart = false;
        Vector3 temp = new Vector3(-76.8f, 0.972f, 30.2f);
        player.transform.position = temp;
        Vector3 rotation = new Vector3(0, 90, 0);
        player.transform.eulerAngles = rotation;
    }
}
