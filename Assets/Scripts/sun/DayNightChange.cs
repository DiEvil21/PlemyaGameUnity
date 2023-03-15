using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightChange : MonoBehaviour
{
    public float timeRemaining = 10;
    public GameObject canvas;
    private float time;
    public bool timerIsRunning = false;
    public bool isDay = true;
    void Start()
    {
        time = timeRemaining;
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                if (isDay)
                {
                    
                    GetComponent<Light>().intensity = timeRemaining / time;
                }
                else 
                {
                    GetComponent<Light>().intensity = 1 - timeRemaining / time;
                }
               
            }
            else
            {
                timeRemaining = time;
                isDay = !isDay;
                if (isDay) 
                {
                    canvas.GetComponent<DayCounter>().plusDay();
                }

            }
        }

    }
}
