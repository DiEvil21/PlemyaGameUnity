using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    public GameObject dayCounterText;
    private int day;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dayCounterText.GetComponent<Text>().text = "Day: " + day; 
    }

    public void plusDay() 
    {
        day += 1;
    }
}
