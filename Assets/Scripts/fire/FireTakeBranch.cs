using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTakeBranch : MonoBehaviour
{
    public float timeRemaining = 5;
    public GameObject restartBtn;
    public bool timerIsRunning = false;
    public GameObject flame;
    void Start()
    {
        timerIsRunning = true;
        restartBtn.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                if (flame.GetComponent<ParticleSystem>().startSize > 0)
                {
                    flame.GetComponent<ParticleSystem>().startSize -= 0.2f;
                }
                else 
                {
                    restartBtn.SetActive(true);
                }
                timeRemaining = 5;
            }
        }
        
    }

    private void OnTriggerEnter(Collider collider) 
    {
        try
        {
            if (collider.transform.parent.gameObject.CompareTag("branch"))
            {
                if (flame.GetComponent<ParticleSystem>().startSize < 6) {
                    flame.GetComponent<ParticleSystem>().startSize += 0.5f;
                    DestroyObject(collider.transform.parent.gameObject);
                }
                
            }
        }
        catch
        {

        }
    }
}
