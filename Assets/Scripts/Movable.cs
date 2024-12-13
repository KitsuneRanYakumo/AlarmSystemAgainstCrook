using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _rotateSpeed = 10;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _camera;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
        Vector3 velocity = _moveSpeed * direction;

        transform.Translate(velocity);
    }

    private void Rotate()
    {
        _body.Rotate(_rotateSpeed * Input.GetAxis(MouseX) * Vector3.up);
        _camera.Rotate(_rotateSpeed * -Input.GetAxis(MouseY) * Vector3.right);
    }
}