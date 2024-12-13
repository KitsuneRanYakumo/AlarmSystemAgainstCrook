using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private KeyCode _interactionButton = KeyCode.E;

    public bool PressedInteractionButton => Input.GetKeyDown(_interactionButton);

    public float HorizontalMovement => Input.GetAxis(Horizontal);

    public float VerticalMovement => Input.GetAxis(Vertical);

    public float HorizontalMovementMouse => Input.GetAxis(MouseX);

    public float VerticalMovementMouse => -Input.GetAxis(MouseY);
}