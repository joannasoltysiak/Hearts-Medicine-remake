using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;
    float nextClient; // time until next client appear
    public WaitingRoom waitingRoom;

    public TextMeshProUGUI endGame;
    public GameObject panel;

    public static int clientsOnMap;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        nextClient = 0f;
        clientsOnMap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            nextClient -= Time.deltaTime;

            if(nextClient < 0f)
            {
                waitingRoom.SpawnClient();
                nextClient = 7f;
            }
        }
        else
        {
            if(clientsOnMap == 0)
            {
                if(GameState.TresholdReached())
                    endGame.text = "This time everyone survived! yeeyy!!";
                else
                    endGame.text = "People died :(("; //😞
                Time.timeScale = 0;
            }
        }
    }

    public void StopTimeAndShowInstruction()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void HideInstruction()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
}
