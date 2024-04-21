using System;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private float _movementTime = 5f;
    [SerializeField] private float _movementSpeed = 1.0f;
    [SerializeField] private float _movementFastSpeed = 3.0f;
    [SerializeField] private float _scrolSpeed = 9.0f;

    [SerializeField] private float _rotationAmount = 9.0f;

    [Space]
    [SerializeField] private Vector2 _limitHorizontal;
    [SerializeField] private Vector2 _limitVertical;
    [SerializeField] private Vector2 _limitDeep;
    [Space]
    [SerializeField] private bool _drawLimit;


    private Vector3 _direction;
    private Vector3 _newPosition;
    private Quaternion _newRotation;


    private Vector3 _dragStartPosition;
    private Vector3 _dragCurrentPosition;


    private float _currentSpeed;

    private void Start()
    {
        _direction = transform.position;
        _newRotation = transform.rotation;
    }


    private void LateUpdate()
    {
        HandleMovmentInput();
        Zoom();
        Rotion();
        HandlerMouseInput();

        transform.position = Vector3.Lerp(transform.position, _newPosition, _movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, _movementTime);

        TryApplyAxisLimit();
    }

    private void TryApplyAxisLimit()
    {
        var xPosition = Math.Clamp(transform.position.x, _limitHorizontal.x, _limitHorizontal.y);
        var zPosition = Math.Clamp(transform.position.z, _limitDeep.x, _limitDeep.y);

        transform.position = new Vector3(xPosition, transform.position.y, zPosition);
    }

    private void HandleMovmentInput()
    {
        SetSpeed();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _direction = transform.forward * vertical * _currentSpeed;
        _direction += transform.right * horizontal * _currentSpeed;

        _newPosition = _direction + transform.position;

    }

    private void SetSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = _movementFastSpeed * Time.deltaTime;
        else
            _currentSpeed = _movementSpeed * Time.deltaTime;
    }

    private void Rotion()
    {
        if (Input.GetKey(KeyCode.Q))
            _newRotation *= Quaternion.Euler(Vector3.up * _rotationAmount * Time.deltaTime);

        else if (Input.GetKey(KeyCode.E))
            _newRotation *= Quaternion.Euler(Vector3.up * -_rotationAmount * Time.deltaTime);

    }

    private void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 direction = _camera.transform.localPosition * _scrolSpeed * scroll * Time.deltaTime * -1;
        direction.x = 0;


        var newPosition = direction + _camera.transform.localPosition;


        _camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition, newPosition, _movementTime);

        var yPosition = Math.Clamp(_camera.transform.localPosition.y, _limitVertical.x, _limitVertical.y);
        var zPosition = yPosition * -1;


        _camera.transform.localPosition = new Vector3(_camera.transform.localPosition.x, yPosition, zPosition);
    }

    private void HandlerMouseInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                _dragStartPosition = ray.GetPoint(entry);
            }
        }

        if (Input.GetMouseButton(1))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                _dragCurrentPosition = ray.GetPoint(entry);

                _newPosition = transform.position + _dragStartPosition - _dragCurrentPosition;
            }

        }
    }




    private void OnDrawGizmos()
    {
        if (_drawLimit)
        {
            DrawLimnit();

            Gizmos.DrawCube(_camera.transform.position, new Vector3(5, 5, 5));
        }
    }


    private void DrawLimnit()
    {
        var addX = 0;
        Gizmos.color = Color.blue;
        //Horizontal
        Gizmos.DrawLine(new Vector3(_limitHorizontal.x+ addX, _limitVertical.x, _limitDeep.x ), new Vector3(_limitHorizontal.y+ addX, _limitVertical.x, _limitDeep.x ));
        Gizmos.DrawLine(new Vector3(_limitHorizontal.x + addX, _limitVertical.y, _limitDeep.x), new Vector3(_limitHorizontal.y + addX, _limitVertical.y, _limitDeep.x));

        Gizmos.DrawLine(new Vector3(_limitHorizontal.x + addX, _limitVertical.y, _limitDeep.y), new Vector3(_limitHorizontal.y + addX, _limitVertical.y, _limitDeep.y));

        Gizmos.DrawLine(new Vector3(_limitHorizontal.x + addX, _limitVertical.x, _limitDeep.y), new Vector3(_limitHorizontal.y + addX, _limitVertical.x, _limitDeep.y));


        //Deep
        Gizmos.DrawLine(new Vector3(_limitHorizontal.x + addX, _limitVertical.x, _limitDeep.x ), new Vector3(_limitHorizontal.x + addX, _limitVertical.x, _limitDeep.y ));
        Gizmos.DrawLine(new Vector3(_limitHorizontal.y + addX, _limitVertical.x, _limitDeep.x ), new Vector3(_limitHorizontal.y + addX, _limitVertical.x, _limitDeep.y ));

        Gizmos.DrawLine(new Vector3(_limitHorizontal.x + addX, _limitVertical.y, _limitDeep.x ), new Vector3(_limitHorizontal.x + addX, _limitVertical.y, _limitDeep.y ));
        Gizmos.DrawLine(new Vector3(_limitHorizontal.y + addX, _limitVertical.y, _limitDeep.x ), new Vector3(_limitHorizontal.y + addX, _limitVertical.y, _limitDeep.y ));


        //vertical


        Gizmos.DrawLine(new Vector3(_limitHorizontal.x + addX, _limitVertical.x, _limitDeep.x ), new Vector3(_limitHorizontal.x + addX, _limitVertical.y, _limitDeep.x));
        Gizmos.DrawLine(new Vector3(_limitHorizontal.y + addX, _limitVertical.x, _limitDeep.y ), new Vector3(_limitHorizontal.y + addX, _limitVertical.y, _limitDeep.y));

        Gizmos.DrawLine(new Vector3(_limitHorizontal.y + addX, _limitVertical.x, _limitDeep.x ), new Vector3(_limitHorizontal.y + addX, _limitVertical.y, _limitDeep.x));
        Gizmos.DrawLine(new Vector3(_limitHorizontal.x + addX, _limitVertical.x, _limitDeep.y ), new Vector3(_limitHorizontal.x + addX, _limitVertical.y, _limitDeep.y));
        Gizmos.DrawLine(transform.position, _camera.transform.position);

    }

}