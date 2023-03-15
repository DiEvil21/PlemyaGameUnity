using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ObjToFollow;
    public float speed;
    private Vector3 deltaPos;
    // Start is called before the first frame update
    void Start()
    {
        deltaPos = transform.position - ObjToFollow.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = ObjToFollow.position + deltaPos;
        Vector3 newCamPosition = ObjToFollow.position + deltaPos;
        transform.position = Vector3.Lerp(transform.position, newCamPosition, speed * Time.deltaTime);
    }
}
