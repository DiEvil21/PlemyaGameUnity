using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : MonoBehaviour
{
    public GameObject item;
    private Transform tree;
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    void Start()
    {
        timerIsRunning = true;
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
                SpawnDropppedItem();
                timeRemaining = 30;
                
            }
        }
    }


    public void SpawnDropppedItem()
    {
        Vector3 treePos = new Vector3(tree.position.x - 1, tree.position.y - 1, tree.position.z - 2);
        Instantiate(item, treePos, Quaternion.identity);
    }
}
