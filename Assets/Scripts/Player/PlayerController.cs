using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public static int woodNum;
    public GameObject restart;
    public float jumpSpeed;
    private Vector2 move;
    private Rigidbody _rigidBody;
    private Vector3 m_Velocity = Vector3.zero;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    public void Jump() {
        if (isGrounded()) {
            _rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        woodNum = 0;
        _rigidBody = GetComponent<Rigidbody>();
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlayer();
    }
    public bool isGrounded() {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void movePlayer() 
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        //_rigidBody.AddForce(movement * speed * Time.deltaTime, ForceMode.VelocityChange);
        //transform.Translate(movement * speed * Time.deltaTime, Space.World);
        //_rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, movement * speed * Time.deltaTime, 0.15f);
        _rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, movement * speed, ref m_Velocity, 0.2f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        try
        {
            if (collider.transform.gameObject.CompareTag("GameOver"))
            {
                restart.SetActive(true);

            }
        }
        catch
        {

        }
    }

}
