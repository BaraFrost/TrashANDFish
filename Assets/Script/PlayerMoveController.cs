using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0.5f;
    private Vector3 moveVector;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity =  moveVector * speed;
    }
}