using System;

using UnityEngine;
using UnityEngine.InputSystem;

public class CamController : MonoBehaviour
{
    [SerializeField] private float _movementTime;
    [SerializeField] private float _movementSpeed = 1.0f;
    [SerializeField] private float _scrolSpeed = 9.0f;
    [SerializeField] private Vector2 limitHorizontal;
    [SerializeField] private Vector2 limitVertical;
    [SerializeField] private Vector2 limitDeep;
    private Vector3 _direction;



    private void Start()
    {
        _direction = transform.position;
    }

    private void Update()
    {
        HandleMovmentInput();
        TryApplyAxisLimit();

    }

    private void TryApplyAxisLimit()
    {
        var xPosition = Math.Clamp(transform.position.x, limitHorizontal.x, limitHorizontal.y);
        var yPosition = Math.Clamp(transform.position.y, limitVertical.x, limitVertical.y);
        var zPosition = Math.Clamp(transform.position.z, limitDeep.x, limitDeep.y);
        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }

    private void HandleMovmentInput()
    {
        float Speed = _movementSpeed * Time.deltaTime;

        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        var scrolDirection = (transform.forward * _scrolSpeed) * scrollDelta;


        var newPositionForward = transform.forward;
        newPositionForward.y = 0;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Debug.Log(vertical);

        //_direction.z = vertical * Speed* Time.deltaTime;
        //_direction.x = horizontal * Speed * Time.deltaTime;

        _direction = newPositionForward * vertical * Speed;
        _direction += transform.right * horizontal * Speed;

        var newPosition = _direction + scrolDirection + transform.position;

        transform.position = Vector3.MoveTowards(transform.position, newPosition, _movementTime);
    }


}