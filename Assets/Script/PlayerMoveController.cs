using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0.5f;
    private Vector3 moveVector;
    [SerializeField]
    private FixedJoystick _joystick;

    [SerializeField]
    private bool _useJoystic;

    [SerializeField]
    private float _mouseInputDeadZoneRadius;

    [SerializeField]
    private float _breakAcceleration;

    [SerializeField]
    private float _minVelocity;

    [SerializeField]
    private AnimationCurve _joysticSpeedCurve;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void MoveWithMouseInput()
    {
        _joystick.gameObject.SetActive(false);
        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Camera.main.WorldToScreenPoint(gameObject.transform.position).z));
        var input = mousePosition - transform.position;
        input.z = 0;
        if (input.magnitude <= _mouseInputDeadZoneRadius)
        {
            moveVector = Vector3.zero;
        }
        else
        {
            moveVector = input.normalized;
        }
    }

    private void MoveWithJoysticInput()
    {
        _joystick.gameObject.SetActive(true);
        float moveX = _joystick.Horizontal;
        float moveY = _joystick.Vertical;
        moveVector = EvaluateJoysticVector(new Vector3(moveX, moveY, 0));
    }

    private Vector3 EvaluateJoysticVector(Vector3 value)
    {
        return _joysticSpeedCurve.Evaluate(value.magnitude) * value;
    }

    private void Move()
    {
        if (moveVector.magnitude == 0)
        {
            Break();
            return;
        }
        float rotZ = Mathf.Atan2(moveVector.x, moveVector.y) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(-180, 0, rotZ);
        rb.velocity = moveVector * speed;
    }

    private void Break()
    {
        rb.velocity = new Vector3(CalculateFloatBreakVelocity(rb.velocity.x),
            CalculateFloatBreakVelocity(rb.velocity.y), 0);
    }

    private float CalculateFloatBreakVelocity(float value)
    {
        if (Mathf.Abs(value) <= _minVelocity)
        {
            return 0;
        }
        return value * _breakAcceleration;
    }

    void Update()
    {
        if (_useJoystic)
        {
            MoveWithJoysticInput();
        }
        else
        {
            MoveWithMouseInput();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
}
