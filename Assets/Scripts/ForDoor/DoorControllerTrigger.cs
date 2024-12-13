using UnityEngine;

public class DoorControllerTrigger : MonoBehaviour
{
    [SerializeField] private UserInput _input;

    private Door _door;
    private bool _hasOpener = false;

    private void Awake()
    {
        _door = GetComponentInChildren<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Key>())
            _hasOpener = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Key>())
            _hasOpener = false;
    }

    private void Update()
    {
        if (_hasOpener == false)
            return;

        if (_input.PressedInteractionButton)
        {
            if (_door.IsOpened)
            {
                _door.Close();
            }
            else
            {
                _door.Open();
            }
        }
    }
}