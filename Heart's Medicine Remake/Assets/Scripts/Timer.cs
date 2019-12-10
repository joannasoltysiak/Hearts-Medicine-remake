using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;
    float nextClient; // time until next client appear
    public WaitingRoom waitingRoom;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        nextClient = 0f;
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
            Time.timeScale = 0;
        }
    }
}
