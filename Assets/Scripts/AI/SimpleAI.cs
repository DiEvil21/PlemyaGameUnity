using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    private Rigidbody _rigidBody;
    public float speed;
    public Vector3 movement;
    private Vector3 m_Velocity = Vector3.zero;

    public float timeRemaining = 2;
    public float timeRemaining2 = 3;
    public bool timerIsRunning = false;
    public bool timerIsRunning2 = false;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        movement = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        timerIsRunning = true;
        timerIsRunning2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        if (_rigidBody.velocity.magnitude < 0.1) 
        {
            timerIsRunning = true;
        }
        _rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, movement * speed, ref m_Velocity, 0.2f);


        if (timerIsRunning2)
        {
            if (timeRemaining2 > 0)
            {
                timeRemaining2 -= Time.deltaTime;
            }
            else
            {
                timeRemaining2 = 4;
                movement = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            }
        }



        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 2;
                
                timerIsRunning = false;
                Debug.Log(_rigidBody.velocity.magnitude + "megnitude");
                if (_rigidBody.velocity.magnitude < 1)
                {
                    Debug.Log("new movement");
                    movement = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
                }
            }
        }
    }
}
