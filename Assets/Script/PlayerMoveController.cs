using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0.5f;
    private Vector3 moveVector;
    public FixedJoystick joystick;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;
        moveVector = new Vector3(moveX, moveY, 0);
        float rotZ = Mathf.Atan2(moveX, moveY) * Mathf.Rad2Deg;
        var curentRotation = rb.rotation;
        rb.rotation = Quaternion.Euler(-180, 0, rotZ);
        rb.velocity =  moveVector * speed;
    }
}
