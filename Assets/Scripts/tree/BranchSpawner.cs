using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BranchSpawner : MonoBehaviour
{
    public GameObject item;
    private Transform tree;
    public GameObject player;
    public float timeRemaining = 30;
    private bool canSpawn = false;
    public bool timerIsRunning = false;
    void Start()
    {
        timerIsRunning = true;
        System.Random r = new System.Random();
        timeRemaining = r.Next(30, 60);
    }

    // Update is called once per frame
    void Update()
    {
        tree = transform;
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {   
                Debug.Log("Tree timer has run out!");
                canSpawn = true;
                timerIsRunning = false;
                System.Random r = new System.Random();
                timeRemaining = r.Next(40, 100);

            }
        }
        float deltaposx = player.transform.position.x - transform.position.x;
        float deltaposy = player.transform.position.y - transform.position.y;
        if (deltaposx > 10f || deltaposx < 10f || deltaposy > 10f || deltaposy < 10f)
        {
            if (canSpawn) 
            {
                Debug.Log(GameObject.FindGameObjectsWithTag("branch").Length);
                if (GameObject.FindGameObjectsWithTag("branch").Length < 11) 
                {
                    Vector3 treePos = new Vector3(tree.position.x + UnityEngine.Random.Range(-1, 1), tree.position.y + UnityEngine.Random.Range(-1, 1), tree.position.z - 2);
                    Instantiate(item, treePos, Quaternion.identity);
                    System.Random r = new System.Random();
                    timeRemaining = r.Next(60, 100);
                    timerIsRunning = true;
                    canSpawn = false;
                }
            }
        }

    }
}
