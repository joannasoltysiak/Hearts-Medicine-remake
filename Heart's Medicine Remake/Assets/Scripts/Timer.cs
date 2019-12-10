using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;
    float nextClient;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        nextClient = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            nextClient += Time.deltaTime;

            if(nextClient > 1f)
            {
                WaitingRoom.SpawnClient();
                nextClient = 0;
            }
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
