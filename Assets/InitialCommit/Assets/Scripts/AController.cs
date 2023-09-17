using UnityEngine;

public class AController : MonoBehaviour
{
    private float _timeCounter;
    private float _width = 2;
    private float _height = 2;
    private float _velocity = 0.09f;
    private float _rotationSpeed = 5;

    private Vector2 _startPosition;

    private delegate Vector2 Trajectory(float x0, float y0, float t, float a, float b);

    private void Awake()
    {
        _startPosition = transform.position;
    }
    
    void Update()
    {
        Move(EllipseTrajectory);
        HandleKeys();
    }

    private void Move(Trajectory trajectory)
    {
        if (_timeCounter >= 2*Mathf.PI)
        {
            _timeCounter = 0;
        }
        _timeCounter += Time.deltaTime * _rotationSpeed;
        transform.position = trajectory(_startPosition.x, _startPosition.y, _timeCounter,
            _width,
            _height
            );
    }

    private Vector2 EllipseTrajectory(float x0, float y0, float t, float a, float b)
    {
        return new (
            x0 + a * Mathf.Cos(t),
            y0 + b * Mathf.Sin(t)
        );
    }

    void HandleKeys()
    {
        Vector2 position = new Vector2();
        if (Input.GetKey(KeyCode.W))
        {
            position.y += _velocity;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= _velocity;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= _velocity;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += _velocity;
        }
        _startPosition += position;
        transform.position += new Vector3(position.x, position.y, 0);
    }
}
