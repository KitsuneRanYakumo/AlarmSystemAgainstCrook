using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField] private UserInput _input;
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _rotateSpeed = 10;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _camera;

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_input.HorizontalMovement, 0, _input.VerticalMovement);
        Vector3 velocity = _moveSpeed * direction;

        transform.Translate(velocity);
    }

    private void Rotate()
    {
        _body.Rotate(_rotateSpeed * _input.HorizontalMovementMouse * Vector3.up);
        _camera.Rotate(_rotateSpeed * _input.VerticalMovementMouse * Vector3.right);
    }
}