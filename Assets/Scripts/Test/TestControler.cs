using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControler : MonoBehaviour
{
    [SerializeField] private float _movementTime;
    [SerializeField] private float _movementSpeed = 1.0f;
    [SerializeField] private float _scrolSpeed = 9.0f;

    private Vector3 _newPosition;



    private void Start()
    {
        _newPosition = transform.position;
    }

    private void Update()
    {
        HandleMovmentInput();

    }

   

    private void HandleMovmentInput()
    {
        float Speed = _movementSpeed * Time.deltaTime;

       


        if (Input.GetKey(KeyCode.W))
        {
            _newPosition += (transform.forward * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _newPosition += (transform.forward * -Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _newPosition += (transform.right * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _newPosition += (transform.right * -Speed);
        }
        transform.position = Vector3.Lerp(transform.position, _newPosition, _movementTime * Time.deltaTime);

    }
}
